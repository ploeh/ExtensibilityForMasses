using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Eval<A, V> : IIntExp<A>
        where A : IIntValue
        where V : IIntVal<A>
    {
        protected readonly V valFact;

        public Eval(V valFact)
        {
            this.valFact = valFact;
        }

        public A Lit(int x)
        {
            return valFact.Lit(x);
        }

        public A Add(A x, A y)
        {
            return valFact.Lit(x.Int + y.Int);
        }
    }
}
