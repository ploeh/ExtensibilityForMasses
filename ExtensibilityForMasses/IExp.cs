using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IExp
    {
        IValue Eval();
        A Accept<A>(IIntAlg<A> vis);
    }
}
