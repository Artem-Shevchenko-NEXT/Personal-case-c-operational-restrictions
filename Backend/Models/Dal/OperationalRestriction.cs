using Backend.Models.Enum;

namespace Backend.Models.Entities;

public class OperationalRestriction
{
  public Guid Id { get; set; }
  public Guid OriginatorUserId { get; set; }
  public Guid CreatedBy { get; set; }
  public RestrictionState State { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime ArchivedAt { get; set; }
  public Guid? OriginalOperationalRestrictionId { get; set; }
}