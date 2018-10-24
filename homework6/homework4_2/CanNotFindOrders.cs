using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class CanNotFindOrder : ApplicationException
    {
        public CanNotFindOrder(string message) : base(message)
        {

        }
    }

    class MyAppException : ApplicationException
    {
        public MyAppException(string message) : base(message)
        {

        }
        public MyAppException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}