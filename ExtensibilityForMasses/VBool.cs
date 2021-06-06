using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class VBool : IValue
    {
        public VBool(bool b)
        {
            Bool = b;
        }

        public int Int => throw new NotImplementedException();

        public bool Bool { get; }
    }
}
