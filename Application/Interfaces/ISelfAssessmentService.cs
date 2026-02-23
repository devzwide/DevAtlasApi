using System;
using DevAtlasApi.Domain.Entities;

namespace DevAtlasApi.Application.Interfaces;

public interface ISelfAssessmentService
{
    Task<List<Question>> GetAllQuestionsAsync();
    Task<AssessmentResult> CreateAssessmentAsync(string chosenArea, string experience, string goal);
}
