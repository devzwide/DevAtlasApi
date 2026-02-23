using System;
using DevAtlasApi.Application.Interfaces;
using DevAtlasApi.Domain.Entities;
using DevAtlasApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevAtlasApi.Application.Services;

public class SelfAssessmentService : ISelfAssessmentService
{
    private readonly ApplicationDbContext _context;

    public SelfAssessmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        var questions = await _context.Questions.Include(q => q.QuestionOptions).ToListAsync();

        return questions;
    }

    public async Task<AssessmentResult> CreateAssessmentAsync(string chosenArea, string experience, string goal)
    {
        var career = await _context.Careers.FirstOrDefaultAsync(c => c.Area == chosenArea);

        if (career == null) throw new Exception("Career not found!");

        int finalScore = CalculateMatchScore(experience, goal);

        var result = new AssessmentResult
        {
            ExperienceLevel = experience,
            CareerGoal = goal,
            MatchScore = finalScore,
            MatchedCareer = career
        };

        _context.AssessmentResults.Add(result);
        await _context.SaveChangesAsync();

        return result;
    }

    private int CalculateMatchScore(string experience, string goal)
    {
        int score = 75;

        if (experience == "Computer Science") score += 15;
        if (experience == "Information Technology") score += 8;

        if (goal == "Data Science") score += 8;
        if (goal == "Data Engineer") score += 5;
        
        return Math.Min(score, 100);
    }
}
