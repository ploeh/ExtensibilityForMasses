using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IStmtAlg<E, S> : IIntBoolAlg<E>
    {
        E Var(string x);
        E Assign(string x, E e);
        S Expr(E e);
        S Comp(S e1, S e2);
    }
}
