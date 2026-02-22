using System;

namespace DevAtlasApi.Domain.Entities;

public class AssessmentResult
{
    public int Id { get; set; }
    public int MatchScore { get; set; }
    public required string CareerGoal { get; set; }
    public required string ExperienceLevel { get; set; }

    // Foreign key linking to the User
    public int UserId { get; set; }
    // Foreign key linking to the Career
    public int MatchedCareerId { get; set; }
    public required Career MatchedCareer { get; set; }
}
