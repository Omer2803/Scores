using Newtonsoft.Json;
using Scores.Client.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scores.Client.BL
{
    class ScoresCalculatorViaDB : IScoresCalculator
    {
        public Dictionary<string, int> GetCalculatedScores()
        {
            Dictionary<string, int> CalculationScores = new Dictionary<string, int>();
            using (ScoresDbContext dbContext = new ScoresDbContext())
            {
                foreach (var sourceLocation in dbContext.SourceLocations)
                {
                    string text = File.ReadAllText(sourceLocation.LocationOnDisk + "/source.json");
                    if (text == null)
                        continue;
                    var scoreModel = JsonConvert.DeserializeObject<ScoreModel>(text);
                    CalculationScores.Add(sourceLocation.Id, scoreModel.score.Sum());
                }
            }
            return CalculationScores;
        }
    }
}
