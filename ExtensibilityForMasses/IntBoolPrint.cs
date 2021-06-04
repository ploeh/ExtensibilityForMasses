using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class IntBoolPrint : IntPrint, IIntBoolAlg<IPrint>
    {
        public IPrint Bool(bool b)
        {
            return new BoolPrint(b);
        }

        private sealed class BoolPrint : IPrint
        {
            private readonly bool b;

            public BoolPrint(bool b)
            {
                this.b = b;
            }

            public string Print()
            {
                return b.ToString();
            }
        }

        public IPrint Iff(IPrint e1, IPrint e2, IPrint e3)
        {
            return new IffPrint(e1, e2, e3);
        }

        private sealed class IffPrint : IPrint
        {
            private readonly IPrint e1;
            private readonly IPrint e2;
            private readonly IPrint e3;

            public IffPrint(IPrint e1, IPrint e2, IPrint e3)
            {
                this.e1 = e1;
                this.e2 = e2;
                this.e3 = e3;
            }

            public string Print()
            {
                return $"if ({e1.Print()}) then {e2.Print()} else {e3.Print()}";
            }
        }
    }
}
