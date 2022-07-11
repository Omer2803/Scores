using Scores.WebService.Models;
using System;
using System.Web.Http;

namespace Scores.WebService.Controllers
{
    [RoutePrefix("api/Scores")]
    public class ScoresController : ApiController
    {
        private readonly IScoresCalculator _scoresCalculator;

        public ScoresController(IScoresCalculator scoresCalculator)
        {
            _scoresCalculator = scoresCalculator;
        }

        [HttpGet]
        [Route("GetCalculatedScores")]
        public IHttpActionResult GetCalculatedScores()
        {
            try
            {
                var calculatedScores = _scoresCalculator.GetCalculationScores();
                return Ok(calculatedScores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
