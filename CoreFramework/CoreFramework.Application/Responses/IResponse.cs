using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Application.Responses
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
