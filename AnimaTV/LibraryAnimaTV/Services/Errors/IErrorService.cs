using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services.Errors
{
    public interface IErrorService
    {
        bool CheckError(object[] arrayArguments);
    }
}
