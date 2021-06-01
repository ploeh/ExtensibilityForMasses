﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public static class IntAlg
    {
        public static A Make3Plus5<A>(this IIntAlg<A> f)
        {
            return f.Add(f.Lit(3), f.Lit(5));
        }

        public static A ParseExp<A>(this IIntAlg<A> f, string s)
        {
            if (int.TryParse(s, out var x))
                return f.Lit(x);
            else
                throw new NotImplementedException();
        }
    }
}
