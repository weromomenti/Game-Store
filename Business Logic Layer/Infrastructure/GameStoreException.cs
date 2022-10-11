using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure
{
    public class GameStoreException : Exception
    {
        public GameStoreException()
        {

        }
        public GameStoreException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}
