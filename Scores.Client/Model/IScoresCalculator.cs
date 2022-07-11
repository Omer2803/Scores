using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scores.Client.Model
{
    interface IScoresCalculator
    {
        Dictionary<string, int> GetCalculatedScores();
    }
}
