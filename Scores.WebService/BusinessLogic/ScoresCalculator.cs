using Newtonsoft.Json;
using Scores.WebService.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scores.WebService.BusinessLogic
{
    public class ScoresCalculator : IScoresCalculator
    {
        private readonly List<SourceLocation> _sourceLocations;
        private Dictionary<string, int> _calculationScores;

        public ScoresCalculator()
        {
            _sourceLocations = new List<SourceLocation>();
            _calculationScores = new Dictionary<string, int>();
            InitSourceLocations();
        }

        public Dictionary<string, int> GetCalculationScores()
        {
            foreach (var sourceLocation in _sourceLocations)
            {
                string text = File.ReadAllText(sourceLocation.LocationOnDisk);
                if (text == null)
                    continue;
                var scoreModel = JsonConvert.DeserializeObject<ScoreModel>(text);
                _calculationScores.Add(sourceLocation.Id, scoreModel.score.Sum());
            }
            return _calculationScores;
        }

        private void InitSourceLocations()
        {
            _sourceLocations.AddRange(new List<SourceLocation>{ 
                new SourceLocation() { Id = "2041F072-6F90-4813-81DA-03A2468010D5", LocationOnDisk=@"C:\VaronisTest\Source1\source.json"},
                new SourceLocation() { Id = "7E2E0C97-6F2F-48B2-91EE-36312247FD76", LocationOnDisk=@"C:\VaronisTest\Source6\source.json"},
                new SourceLocation() { Id = "DFA632E6-3D49-409C-BF8F-4D875D333282", LocationOnDisk=@"C:\VaronisTest\Source7\source.json"},
                new SourceLocation() { Id = "E9B3C5A4-E044-4985-9918-6A031920FFFE", LocationOnDisk=@"C:\VaronisTest\Source2\source.json"},
                new SourceLocation() { Id = "C02897F8-9DA6-429C-9A6F-7D0B60AAC979", LocationOnDisk=@"C:\VaronisTest\Source8\source.json"},
                new SourceLocation() { Id = "B38288D4-EFF8-4B36-A4AF-8F2EE4F24836", LocationOnDisk=@"C:\VaronisTest\Source4\source.json"},
                new SourceLocation() { Id = "E7855763-F7BB-45C4-9309-9668093A4DFE", LocationOnDisk=@"C:\VaronisTest\Source3\source.json"},
                new SourceLocation() { Id = "2E3B6FE1-838B-46BA-B10B-ABE502D2FA28", LocationOnDisk=@"C:\VaronisTest\Source9\source.json"},
                new SourceLocation() { Id = "ED182B16-08F8-41BB-9BE1-C5037D3F5E3B", LocationOnDisk=@"C:\VaronisTest\Source10\source.json"},
                new SourceLocation() { Id = "817DB312-8D26-4AC1-B829-FA0EBF063D83", LocationOnDisk=@"C:\VaronisTest\Source5\source.json"}
            });
        }

       
    }
}