using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentGenerator.Utilities;
using Xceed.Words.NET;

namespace DocumentGenerator.FeatureSpec
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Check Correct Arguments and Log any Warning or Throw Exception for Error
                ArgumentsHandler.IsValidArguments(args);
            }
            catch (ArgumentException argsEx)
            {
                Console.WriteLine(argsEx.Message);
            }

            //Set Variables for Input and Output Directories
            string inputDir = args[0];
            string outputDir = args[1];

            //Get All Gherkin Scripts Feature Wise : Dictionary{Feature:[gH1,gH2,..],...}
            Dictionary<string, string[]> FeatureTree = DirectoryHandler.GetAllGherkinScripts(inputDir);

            //Loop through the Dict and Generate FS for each Feature
            foreach(var dItem in FeatureTree)
            {
                var doc = DocX.Create(outputDir + dItem.Key + ".docx");

                foreach (string gherkinScript in dItem.Value)
                {
                    var feature = GherkinParserHandler.GetFeature(gherkinScript);

                    DocumentHandler.GenerateFeatureSpecDocument(feature, doc);
                }
            }
        }
    }
}
