using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class EvalIntAlg : IIntAlg<int>
    {
        public int Add(int e1, int e2)
        {
            return e1 + e2;
        }

        public int Lit(int x)
        {
            return x;
        }
    }
}
