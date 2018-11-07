using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Ast;
using Xceed.Words.NET;

namespace DocumentGenerator.Utilities.Interfaces
{
    public interface IDocumentHandler
    {
        void GenerateFeatureSpecDocument(GherkinDocument feature, DocX doc);
    }
}
