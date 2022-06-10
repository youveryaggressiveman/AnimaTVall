using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services.Errors.NullReferenceException
{
    public class NullReferenceExceptionService : IErrorService
    {
        public bool CheckError(object[] arrayArguments)
        {
            foreach (var argument in arrayArguments)
            {
                if (argument == null) return false;
            }

            return true;
        }
    }
}
