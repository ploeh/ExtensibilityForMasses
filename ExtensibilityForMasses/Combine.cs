using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Combine<A, B> : IIntAlg<Pair<A, B>>
    {
        private readonly IIntAlg<A> v1;
        private readonly IIntAlg<B> v2;

        public Combine(IIntAlg<A> v1, IIntAlg<B> v2)
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
