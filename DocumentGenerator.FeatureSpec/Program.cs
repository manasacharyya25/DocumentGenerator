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
        public static string inputDir;
        public static string outputDir;

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
            Program.inputDir = args[0];
            Program.outputDir = args[1];

            //Get All Gherkin Scripts Feature Wise : Dictionary{Feature:[gH1,gH2,..],...}
            Dictionary<string, string[]> FeatureTree = DirectoryHandler.GetAllGherkinScripts(inputDir);

            //Loop through the Dict and Generate FS for each Feature
            foreach(var dictionaryItem in FeatureTree)
            {
                GenerateFS(dictionaryItem);
            }

            




            //--------------Populate Contents into Document
            //--------------Save Document
            //Move to Next Feature Directory
        }

        private static void GenerateFS(KeyValuePair<string, string[]> dItem)
        {
            var doc = DocX.Create(Program.outputDir + dItem.Key + ".docx");
           
            foreach(string gherkinScript in dItem.Value)
            {
                
            }

            

            Console.ReadLine();
        }
    }
}
