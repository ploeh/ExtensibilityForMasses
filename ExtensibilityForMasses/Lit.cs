using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class Lit : IExp
    {
        private readonly int x;

        public Lit(int x)
        {
            this.x = x;
        }

        public IValue Eval()
        {
            return new VInt(x);
        }
    }
}
