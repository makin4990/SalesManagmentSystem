using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Application.Responses
{
    public class ErorrResponse:Response
    {
        public ErorrResponse(string message) : base(true, message)
        {

        }

        public ErorrResponse() : base(true)
        {

        }
    }
}
