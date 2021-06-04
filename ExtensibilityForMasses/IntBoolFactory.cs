using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class IntBoolFactory : IntFactory, IIntBoolAlg<IExp>
    {
        public IExp Bool(bool b)
        {
            return new Bool(b);
        }

        public IExp Iff(IExp e1, IExp e2, IExp e3)
        {
            return new Iff(e1, e2, e3);
        }
    }
}
