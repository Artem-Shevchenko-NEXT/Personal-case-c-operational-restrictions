namespace Backend.Services;

using Backend.Models.DTOs;
using Backend.Models.Enum;
using Backend.Models.Entities;

using Npgsql.Internal;

using System.ComponentModel.DataAnnotations;

public class StateMachine
{
    public void Transition(OperationalRestriction operationalRestriction)
    {
        bool requirements = Require(operationalRestriction);

        if (requirements)
        {
            operationalRestriction.State = operationalRestriction.State switch
        {
            RestrictionState.ACTIVE          => RestrictionState.PENDING_CANCELLATION,
            RestrictionState.PENDING_CANCELLATION   => RestrictionState.CANCELLATION_APPROVED,
            RestrictionState.CANCELLATION_APPROVED       => RestrictionState.OUT_OF_FORCE,
            RestrictionState.OUT_OF_FORCE => RestrictionState.AWAITING_OPERATOR_SIGN_OUT,
            RestrictionState.AWAITING_OPERATOR_SIGN_OUT => RestrictionState.ARCHIVED,
            _ => throw new InvalidOperationException($"No next state after {operationalRestriction.State}.")
        };
        }
    }


    public bool Require(OperationalRestriction operationalRestriction)
    {
        switch (operationalRestriction.State)
        {
            case RestrictionState.ACTIVE:
                return ActiveStateRequirements(operationalRestriction);

            case RestrictionState.PENDING_CANCELLATION:
                return PendingCancellationStateRequirements(operationalRestriction);

            case RestrictionState.CANCELLATION_APPROVED:
                return CancellationApprovedStateRequirements(operationalRestriction);

            case RestrictionState.OUT_OF_FORCE:
                return OutOfForceStateRequirements(operationalRestriction);

            default:
                throw new InvalidOperationException("No matching state requirements found");
        }
    }

    // Functions for each state that checks the requirements needed to transition
    public bool ActiveStateRequirements(OperationalRestriction operationalRestriction)
    {
        if (!operationalRestriction.SignatureSheet.OriginatorCancellation.Signed)
            throw new InvalidOperationException("Originator cancellation signiture missing");
        
        return true;
    }

    public bool PendingCancellationStateRequirements(OperationalRestriction operationalRestriction)
    {
        if (!operationalRestriction.SignatureSheet.DOMCancellation.Signed)
            throw new InvalidOperationException("DOM cancellation approval signiture missing");
        
        return true;
    }

    public bool CancellationApprovedStateRequirements(OperationalRestriction operationalRestriction)
    {
        if (!operationalRestriction.SignatureSheet.CRSCancellation.Signed)
            throw new InvalidOperationException("CRS cancellation signiture missing");
        
        return true;
    }

    public bool OutOfForceStateRequirements(OperationalRestriction operationalRestriction)
    {
        for (int i=0; i < SignatureSheet.Count; i++)
        {
            if (SignatureSheet[i].Type = OperatorCancellation)
            {
                if (!SignatureSheet[i].Signed)
                    throw new InvalidOperationException("Operator cancellation signature missing");
            }
        }

        return true;

    }


}