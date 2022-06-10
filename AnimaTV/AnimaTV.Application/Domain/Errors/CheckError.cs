using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimaTV.Application.Domain.Errors
{
    public class CheckError
    {
        protected bool CheckOnNullOrWhiteSpace(string[] arguments)
        {
            foreach (var argument in arguments)
            {
                if (string.IsNullOrWhiteSpace(argument))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
