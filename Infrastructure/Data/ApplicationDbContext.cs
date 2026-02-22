using System;
using DevAtlasApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevAtlasApi.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Career> Careers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<AssessmentResult> AssessmentResults { get; set; }
}
