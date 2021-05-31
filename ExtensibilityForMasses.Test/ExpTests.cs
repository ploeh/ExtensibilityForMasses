using Ploeh.Study.ExtensibilityForMasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExtensibilityForMasses.Test
{
    public sealed class ExpTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(00)]
        [InlineData(01)]
        [InlineData(11)]
        public void EvalLit(int x)
        {
            var sut = new Lit(x);

            var actual = sut.Eval();

            var vint = Assert.IsAssignableFrom<VInt>(actual);
            Assert.Equal(x, vint.Int);
        }
    }
}
