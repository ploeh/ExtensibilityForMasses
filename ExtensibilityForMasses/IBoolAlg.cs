using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IBoolAlg<A>
    {
        A Bool(bool b);
        A Iff(A b, A e1, A e2);
    }
}
