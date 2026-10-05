// initial idea for cancellation part of the state machine - will be adjusted to match data models

public enum Role { Originator, DOM, CRS, Operator }

public enum CancellationStatus
{
    Active,                 // OR is in force
    SignedByOriginator,     // step 1
    ApprovedByDom,          // step 2
    MitigationsCancelled,   // step 3 (CRS signed), OR is out of force, waiting for signing list to archive
    Archived               // step 4: everyone signed
}

public class OperationalRestriction
{
    public CancellationStatus Status { get; private set; } = CancellationStatus.Active;

    // True when the current step has been signed. Must be true to move on.
    public bool Signed { get; private set; } = false;

    // Everyone who must sign the signing list (all operators + all DOM)
    public HashSet<string> RequiredSigners { get; } = new();
    public HashSet<string> SignedBy { get; } = new();

    public void OriginatorSigns(Role role)
    {
        Require(role, Role.Originator, CancellationStatus.Active);
        Signed = true;
    }

    public void DomApprovesAndSigns(Role role)
    {
        Require(role, Role.DOM, CancellationStatus.SignedByOriginator);
        Signed = true;
    }

    public void CrsCancelsMitigationsAndSigns(Role role)
    {
        Require(role, Role.CRS, CancellationStatus.ApprovedByDom);
        Signed = true;
    }

    public void SignSigningList(Role role, string userId)
    {
        if (role is not (Role.Operator or Role.DOM))
            throw new UnauthorizedAccessException("Only operators and DOM can sign the list.");
        if (Status != CancellationStatus.MitigationsCancelled)
            throw new InvalidOperationException("Signing list is not open yet.");
        if (!RequiredSigners.Contains(userId))
            throw new InvalidOperationException("User is not on the signing list.");

        SignedBy.Add(userId);

        // The step counts as signed only when everyone has signed
        Signed = SignedBy.SetEquals(RequiredSigners);
    }

    // The gate: cannot move to the next state unless Signed is true
    public void Advance()
    {
        if (!Signed)
            throw new InvalidOperationException($"Cannot leave {Status}: it has not been signed.");

        Status = Status switch
        {
            CancellationStatus.Active               => CancellationStatus.SignedByOriginator,
            CancellationStatus.SignedByOriginator   => CancellationStatus.ApprovedByDom,
            CancellationStatus.ApprovedByDom        => CancellationStatus.MitigationsCancelled,
            CancellationStatus.MitigationsCancelled => CancellationStatus.Archived,
            _ => throw new InvalidOperationException($"No next state after {Status}.")
        };

        Signed = false;   // the new state starts unsigned
    }

    private void Require(Role actual, Role expected, CancellationStatus expectedStatus)
    {
        if (actual != expected)
            throw new UnauthorizedAccessException($"Only {expected} can do this step.");
        if (Status != expectedStatus)
            throw new InvalidOperationException($"OR must be in {expectedStatus}, but is {Status}.");
        if (Signed)
            throw new InvalidOperationException("This step is already signed.");
    }
}