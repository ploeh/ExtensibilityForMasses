using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class IntBoolFactory2 : Union<IExp>
    {
        public IntBoolFactory2() : base(new BoolFactory(), new IntFactory())
        {
        }
    }
}
