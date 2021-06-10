using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class GUnion<A, V1, V2> : IExpIntBool<A>
        where V1 : IBoolAlg<A>
        where V2 : IIntAlg<A>
    {
        private readonly V1 v1;
        private readonly V2 v2;

        public GUnion(V1 v1, V2 v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public A Bool(bool b)
        {
            return v1.Bool(b);
        }

        public A Iff(A b, A e1, A e2)
        {
            return v1.Iff(b, e1, e2);
        }

        public A Lit(int x)
        {
            return v2.Lit(x);
        }

        public A Add(A e1, A e2)
        {
            return v2.Add(e1, e2);
        }
    }
}
