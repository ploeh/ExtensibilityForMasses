using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Add : IExp
    {
        private readonly IExp l;
        private readonly IExp r;

        public Add(IExp l, IExp r)
        {
            this.l = l;
            this.r = r;
        }

        public A Accept<A>(IIntAlg<A> vis)
        {
            return vis.Add(l.Accept(vis), r.Accept(vis));
        }

        public IValue Eval()
        {
            return new VInt(l.Eval().Int + r.Eval().Int);
        }
    }
}
