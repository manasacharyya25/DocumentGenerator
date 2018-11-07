using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Utilities.Interfaces
{
    public interface IDirectoryHandler
    {
        void GetAllGherkinScripts(string inputDir);

        void GeneateOutputFileName(string inputDir);
    }
}
