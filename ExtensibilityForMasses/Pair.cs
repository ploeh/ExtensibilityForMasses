using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Pair<A, B>
    {
        public Pair(A a, B b)
        {
            TheA = a;
            TheB = b;
        }

        public A TheA { get; }
        public B TheB { get; }
    }
}
