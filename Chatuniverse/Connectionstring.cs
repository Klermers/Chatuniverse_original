using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatUniverseInterface;

namespace Chatuniverse
{
    public class Connectionstring : IConnectionString
    {
        private string connstring;
        public string Connstring { get { return connstring; }}

        public Connectionstring(string consstring)
        {
            this.connstring = consstring;
        }
    }
}
