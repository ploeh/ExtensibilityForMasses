﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public static class IntAlg
    {
        public static A Make3Plus5<A>(IIntAlg<A> f)
        {
            return f.Add(f.Lit(3), f.Lit(5));
        }
    }
}