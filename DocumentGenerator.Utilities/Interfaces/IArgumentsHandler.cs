using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Utilities.Interfaces
{
    public interface IArgumentsHandler
    {
        bool IsValidArguments(string[] args);
    }
}
