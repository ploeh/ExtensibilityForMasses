using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Debug : Combine<IExp, IPrint>
    {
        public Debug() : base(new IntFactory(), new IntPrint())
        {
        }

        public override Pair<IExp, IPrint> Add(Pair<IExp, IPrint> e1, Pair<IExp, IPrint> e2)
        {
            Console.WriteLine($"The first expression {e1.TheB.Print()} evaluates to {e1.TheA.Eval()}");
            Console.WriteLine($"The second expression {e2.TheB.Print()} evaluates to {e2.TheA.Eval()}");
            return base.Add(e1, e2);
        }
    }
}
