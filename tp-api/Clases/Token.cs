using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clases
{
    public class Token
    {
        public string TokenAccess { get; set; }
        public DateTime Expires { get; set; }
        public string Refresh { get; set; }
        public bool Active { get; set; }
    }
}
