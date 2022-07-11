using Scores.Client.BL;
using System;
using System.Collections.Generic;

namespace Scores.Client
{
    class Program
    {
        private static Dictionary<string, int> _calculationScores;
        private static ScoresCalculatorFactory _scoresCalculatorFactory;

        static void Main(string[] args)
        {
            var answer = GetInputFromUser();
            if (answer == 0)
                return;

            _scoresCalculatorFactory = new ScoresCalculatorFactory();
            _calculationScores = _scoresCalculatorFactory.GetCalculateScoresAccordingUserChoice(answer);


            foreach (var calculationScore in _calculationScores)
            {
                Console.WriteLine(string.Format("ID-{0}, sum-{1}", calculationScore.Key, calculationScore.Value));
            }

            Console.ReadKey();
        }

        private static int GetInputFromUser()
        {
            int answer;
            Console.WriteLine("Please select one of the options to get calculation scores:");
            Console.WriteLine("1-DB, 2- Web service");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out answer))
            {
                Console.WriteLine("Incorrect input");
                return 0;
            }
            return answer == 1 || answer == 2 ? answer : 0;
        }
    }
}
