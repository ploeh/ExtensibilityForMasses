using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public sealed class Iff : IExp
    {
        private readonly IExp e1;
        private readonly IExp e2;
        private readonly IExp e3;

        public Iff(IExp e1, IExp e2, IExp e3)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.e3 = e3;
        }

        public IValue Eval()
        {
            return e1.Eval().Bool ? e2.Eval() : e3.Eval();
        }
    }
}
