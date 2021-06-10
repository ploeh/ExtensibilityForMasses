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

        public override bool Equals(object obj)
        {
            return obj is Pair<A, B> pair &&
                   EqualityComparer<A>.Default.Equals(TheA, pair.TheA) &&
                   EqualityComparer<B>.Default.Equals(TheB, pair.TheB);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TheA, TheB);
        }
    }
}
