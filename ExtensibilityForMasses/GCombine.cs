using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class GCombine<A, B, V1, V2> : IIntAlg<Pair<A, B>>
        where V1 : IIntAlg<A>
        where V2 : IIntAlg<B>
    {
        private readonly V1 v1;
        private readonly V2 v2;

        public GCombine(V1 v1, V2 v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Pair<A, B> Lit(int x)
        {
            return new Pair<A, B>(v1.Lit(x), v2.Lit(x));
        }

        public Pair<A, B> Add(Pair<A, B> e1, Pair<A, B> e2)
        {
            return new Pair<A, B>(
                v1.Add(e1.TheA, e2.TheA),
                v2.Add(e1.TheB, e2.TheB));
        }
    }
}
