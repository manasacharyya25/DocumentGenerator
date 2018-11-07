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

            //Traverse The Input Directory to Get a List of Gherkin Scripts for Each Feature Directory : One Feature Per Iteration
            string[] Features = System.IO.Directory.GetDirectories(inputDir);

            foreach(var feature in Features)
            {
                //----Generate the Document
                //----------Get feature Name
                string featureFileName = outputDir + feature.Substring(feature.LastIndexOf(@"\"))+".docx";
                var doc = DocX.Create(featureFileName);

                string[] FeatureRequirements = System.IO.Directory.GetFiles(feature);
                

                foreach(var gherkinScript in FeatureRequirements)
                {
                    //--------------Parse each Gherkin Script
                    var gherkinFeature = GherkinParserHandler.GetFeature(gherkinScript);

                    GenerateFSDocument(gherkinFeature,doc);
                }

            }


            
            
            //--------------Populate Contents into Document
            //--------------Save Document
            //Move to Next Feature Directory
        }
    }
}
