using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class IncompleteMasterDataException : Exception
    {
        public IncompleteMasterDataException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; set; }
    }

}
