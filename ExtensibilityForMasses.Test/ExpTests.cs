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

        [Theory]
        [InlineData(-1, 00, -1)]
        [InlineData(-1, 01, 00)]
        [InlineData(00, 00, 00)]
        [InlineData(00, 01, 01)]
        [InlineData(01, 01, 02)]
        [InlineData(07, 03, 10)]
        public void EvalSimpleAddition(int l, int r, int expected)
        {
            var sut = new Add(new Lit(l), new Lit(r));

            var actual = sut.Eval();

            var vint = Assert.IsAssignableFrom<VInt>(actual);
            Assert.Equal(expected, vint.Int);
        }
    }
}
