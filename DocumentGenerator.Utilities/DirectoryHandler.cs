using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Utilities
{
    public class DirectoryHandler
    {
        public static Dictionary <string,string[]> FeatureTree;

        public static Dictionary<string, string[]> GetAllGherkinScripts(string inputDir)
        {
            FeatureTree = new Dictionary<string, string[]>();


            //Traverse The Input Directory to Get a List of Gherkin Scripts for Each Feature Directory : One Feature Per Iteration
            string[] Features = System.IO.Directory.GetDirectories(inputDir);

            
            foreach (var feature in Features)
            {
                //Get feature Name
                string FeatureName = feature.Substring(feature.LastIndexOf(@"\"));
                
                //Get Array of Feature Requirements i.e Gherkin Scripts
                string[] FeatureRequirements = System.IO.Directory.GetFiles(feature);

                //Generate a Key-Value in Dictionary
                FeatureTree.Add(FeatureName, FeatureRequirements);
            }

            return FeatureTree;

        }

        public void GeneateOutputFileName(string inputDir)
        {

        }
    }
}
