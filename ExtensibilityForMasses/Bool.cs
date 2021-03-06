using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public sealed class Bool : IExp
    {
        private readonly bool b;

        public Bool(bool b)
        {
            this.b = b;
        }

        public IValue Eval()
        {
            return new VBool(b);
        }
    }
}
