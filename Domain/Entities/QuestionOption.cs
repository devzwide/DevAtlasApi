using System;

namespace DevAtlasApi.Domain.Entities;

public class QuestionOption
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required string Value { get; set; }

    // Foreign key to Questions entity
    public int QuestionId { get; set; }
    public required Question Question { get; set; }
}
