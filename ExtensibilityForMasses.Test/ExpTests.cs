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
            var actual = sut.Accept(new EvalIntAlg());
            Assert.Equal(x, actual);
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
            var actual = sut.Accept(new EvalIntAlg());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 00, 00, -1)]
        [InlineData(00, 00, 00, 00)]
        [InlineData(01, 00, 00, 01)]
        [InlineData(01, 02, 00, 03)]
        [InlineData(01, 02, 04, 07)]
        public void EvalNestedAddition(int x, int y, int z, int expected)
        {
            var sut = new Add(new Add(new Lit(x), new Lit(y)), new Lit(z));
            var actual = sut.Accept(new EvalIntAlg());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, "-1")]
        [InlineData(00,  "0")]
        [InlineData(10, "10")]
        public void PrintLit(int x, string expected)
        {
            var sut = new Lit(x);
            var actual = sut.Accept(new Print2());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 00, 00, "-1 + 0 + 0")]
        [InlineData(00, 00, 00,  "0 + 0 + 0")]
        [InlineData(01, 00, 00,  "1 + 0 + 0")]
        [InlineData(01, 02, 00,  "1 + 2 + 0")]
        [InlineData(01, 02, 04,  "1 + 2 + 4")]
        [InlineData(11, 03, 04, "11 + 3 + 4")]
        public void PrintAddition(int x, int y, int z, string expected)
        {
            var sut = new Add(new Lit(x), new Add(new Lit(y), new Lit(z)));
            var actual = sut.Accept(new Print2());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3Plus5()
        {
            IExp e = IntAlg.Make3Plus5(new IntFactory());
            var actual = e.Accept(new EvalIntAlg());
            Assert.Equal(3 + 5, actual);
        }

        [Fact]
        public void UseMake3Plus5AsExtensionMethod()
        {
            var exp = new IntFactory().Make3Plus5();
            var actual = exp.Accept(new Print2());
            Assert.Equal("3 + 5", actual);
        }
    }
}
