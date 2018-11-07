using DocumentGenerator.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator.Utilities
{
    public class ArgumentsHandler
    {
        public static bool IsValidArguments(string[] args)
        {
            if (args.Length >= 2)
            {
                if (System.IO.Directory.Exists(args[0]))
                {
                    if (System.IO.Directory.Exists(args[1]))
                    {
                        return true;
                    }
                    else
                    {
                        throw new System.ArgumentException(args[1] + " is not a valid directory");
                    }
                }
                else
                {
                    throw new System.ArgumentException(args[0] + " is not a valid directory");
                }
            }
            else
            {
                throw new System.ArgumentException("Required Arguments Not Provided");
            }
        }
    }
}
