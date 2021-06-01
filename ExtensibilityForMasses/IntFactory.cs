using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class IntFactory : IIntAlg<IExp>
    {
        public IExp Add(IExp e1, IExp e2)
        {
            return new Add(e1, e2);
        }

        public IExp Lit(int x)
        {
            return new Lit(x);
        }
    }
}
