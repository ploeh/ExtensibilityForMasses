using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IIntExp<A> : IIntVal<A>
    {
        A Add(A x, A y);
    }
}
