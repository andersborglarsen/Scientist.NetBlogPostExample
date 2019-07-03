using GitHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace VatService.Service
{
    public class MyResultPublisher : IResultPublisher
    {


        public Task Publish<T, TClean>(Result<T, TClean> result)
        {


            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\temp\log.txt"))
            {
                file.WriteLine($"Publishing results for experiment '{result.ExperimentName}'");
                file.WriteLine($"Result: {(result.Matched ? "MATCH" : "MISMATCH")}");
                file.WriteLine($"Control value: {JsonConvert.SerializeObject(result.Control.Value)}");
                file.WriteLine($"Control duration: {result.Control.Duration}");
                foreach (var observation in result.Candidates)
                {
                    file.WriteLine($"Candidate name: {observation.Name}");
                    file.WriteLine($"Candidate value: {JsonConvert.SerializeObject(result.Control.Value)}");
                    file.WriteLine($"Candidate duration: {observation.Duration}");
                }

                if (result.Mismatched)
                {
                    file.WriteLine($"{result.Control.Value} differs from {result.Control.Value}");
                }

            }

            return Task.FromResult(0);
        }
    }
}
