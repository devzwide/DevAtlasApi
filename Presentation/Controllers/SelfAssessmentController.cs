using DevAtlasApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevAtlasApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfAssessmentController : ControllerBase
    {
        private readonly ISelfAssessmentService _selfAssessmentService;

        public SelfAssessmentController(ISelfAssessmentService selfAssessmentService)
        {
            _selfAssessmentService = selfAssessmentService;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            try
            {
                var questions = await _selfAssessmentService.GetAllQuestionsAsync();

                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitResult([FromBody] QuizSubmissionForm quizSubmissionForm)
        {
            try
            {
                var result = await _selfAssessmentService.CreateAssessmentAsync(
                    quizSubmissionForm.CareerArea,
                    quizSubmissionForm.ExperienceLevel,
                    quizSubmissionForm.CareerGoal
                );
    
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class QuizSubmissionForm
    {
        public required string CareerArea { get; set; }
        public required string ExperienceLevel { get; set; }
        public required string CareerGoal { get; set; }
    }
}
