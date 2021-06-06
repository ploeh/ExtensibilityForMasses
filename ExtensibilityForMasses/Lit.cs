using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Lit : IExp
    {
        private readonly int x;

        public Lit(int x)
        {
            this.x = x;
        }

        public A Accept<A>(IIntAlg<A> vis)
        {
            return vis.Lit(x);
        }

        public IValue Eval()
        {
            throw new NotImplementedException();
        }
    }
}
