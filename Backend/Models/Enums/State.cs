namespace Backend.Models.Enums;

public enum State
{
    Draft,
    PendingDomApproval,
    ReturnedForChanges,
    CancelledRefused,
    Approved,
    Active,
    Empty,
    PendingCancellation,
    OutOfForce,
    AwaitingOperatorSignatures,
    AwaitingOperatorSignOut,
    Archived
}