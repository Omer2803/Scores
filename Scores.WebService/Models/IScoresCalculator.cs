using System.Collections.Generic;

namespace Scores.WebService.Models
{
    public interface IScoresCalculator
    {
        Dictionary<string, int> GetCalculationScores();
    }
}
