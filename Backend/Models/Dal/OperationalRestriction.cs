namespace Backend.Models.Entities;

// Represents an Operational Restriction stored in the database
public class OperationalRestriction
{
    public Guid Id { get; set; }

    public string Purpose { get; set; } = string.Empty;

    public DateTime EffectiveFrom { get; set; }

    public string Duration { get; set; } = string.Empty;

    public string SituationDescription { get; set; } = string.Empty;

    public string RestrictionDescription { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}