using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class IntPrint : IIntAlg<IPrint>
    {
        public IPrint Lit(int x)
        {
            return new LitPrint(x);
        }

        private sealed class LitPrint : IPrint
        {
            private readonly int x;

            public LitPrint(int x)
            {
                this.x = x;
            }

            public string Print()
            {
                return x.ToString();
            }
        }

        public IPrint Add(IPrint e1, IPrint e2)
        {
            return new AddPrint(e1, e2);
        }

        private sealed class AddPrint : IPrint
        {
            private readonly IPrint e1;
            private readonly IPrint e2;

            public AddPrint(IPrint e1, IPrint e2)
            {
                this.e1 = e1;
                this.e2 = e2;
            }

            public string Print()
            {
                return $"{e1.Print()} + {e2.Print()}";
            }
        }
    }
}
