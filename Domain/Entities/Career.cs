using System;

namespace DevAtlasApi.Domain.Entities;

public class Career
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Area { get; set; }
    
    // ICollection of AssessmentResult with One-to-many relationship
    public ICollection<AssessmentResult> AssessmentResults { get; set; } = new List<AssessmentResult>();
}
