using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public sealed class Iff : IExp
    {
        public A Accept<A>(IIntAlg<A> vis)
        {
            throw new NotImplementedException();
        }
    }
}
