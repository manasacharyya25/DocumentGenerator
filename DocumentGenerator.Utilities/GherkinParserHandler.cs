using Gherkin;
using Gherkin.Ast;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Utilities
{
    public class GherkinParserHandler
    {
        public static  GherkinDocument GetFeature(string gherkinScript)
        {
            Parser p = new Parser();
            TextReader gherkinReader = File.OpenText(gherkinScript);
            var feature = p.Parse(gherkinReader);

            return feature;
        }

    }
}
