using System;

namespace DevAtlasApi.Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public required string Text { get; set; }
    
    // ICollection of QuestionOption with One-to-many relationship
    public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
}

