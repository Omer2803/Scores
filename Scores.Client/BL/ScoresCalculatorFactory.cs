using Scores.Client.Model;
using System.Collections.Generic;

namespace Scores.Client.BL
{
    class ScoresCalculatorFactory
    {
        private IScoresCalculator scoresCalculator;
       
        public Dictionary<string, int> GetCalculateScoresAccordingUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    scoresCalculator = new ScoresCalculatorViaDB();
                    break;
                case 2:
                    scoresCalculator = new ScoresCalculatorViaWebService();
                    break;
            }

            return scoresCalculator.GetCalculatedScores();
        }
    }
}
