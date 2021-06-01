using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public sealed class Print2 : IIntAlg<string>
    {
        public string Add(string e1, string e2)
        {
            return $"{e1} + {e2}";
        }

        public string Lit(int x)
        {
            return x.ToString();
        }
    }
}
