using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IIntBoolAlg<A> : IIntAlg<A>
    {
        A Bool(bool b);
        A Iff(A e1, A e2, A e3);
    }
}
