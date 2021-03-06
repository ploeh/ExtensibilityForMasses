using Ploeh.Study.ExtensibilityForMasses;
using System;
using System.Collections.Generic;
using System.IO;
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
            var actual = sut.Eval().Int;
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
            var actual = sut.Eval().Int;
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
            var actual = sut.Eval().Int;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, "-1")]
        [InlineData(00,  "0")]
        [InlineData(10, "10")]
        public void PrintLit(int x, string expected)
        {
            var sut = new Print2();
            var actual = sut.Lit(x);
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
            var sut = new Print2();
            var actual = sut.Add(sut.Lit(x), sut.Add(sut.Lit(y), sut.Lit(z)));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3Plus5()
        {
            IExp e = IntAlg.Make3Plus5(new IntFactory());
            var actual = e.Eval().Int;
            Assert.Equal(3 + 5, actual);
        }

        [Fact]
        public void UseMake3Plus5AsExtensionMethod()
        {
            var actual = new Print2().Make3Plus5();
            Assert.Equal("3 + 5", actual);
        }

        [Theory]
        [InlineData("-98", -98)]
        [InlineData("-04", -04)]
        [InlineData("000", 000)]
        [InlineData("002", 002)]
        [InlineData("042", 042)]
        [InlineData("119", 119)]
        public void ParseIntegers(string s, int expected)
        {
            var actual = new EvalIntAlg().ParseExp(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(  "-1 + -2", -3)]
        [InlineData(  "-1 +  2", 01)]
        [InlineData(  " 0 +  0", 00)]
        [InlineData(  " 0 +  2", 02)]
        [InlineData(  "10 +  2", 12)]
        [InlineData(  "19 + 23", 42)]
        [InlineData("1 + 2 + 3", 06)]
        public void ParseAndEvaluateSums(string s, int expected)
        {
            var actual = new EvalIntAlg().ParseExp(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-4, "-4")]
        [InlineData(00,  "0")]
        [InlineData(07,  "7")]
        [InlineData(24, "24")]
        public void PrintLitViaInterface(int x, string expected)
        {
            var sut = new IntPrint();
            var actual = sut.Lit(x).Print();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2, -4, "-2 + -4")]
        [InlineData(-3, 17, "-3 + 17")]
        [InlineData(88, 91, "88 + 91")]
        public void PrintSumViaInterface(int x, int y, string expected)
        {
            var sut = new IntPrint();
            var actual = sut.Add(sut.Lit(x), sut.Lit(y)).Print();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Use3Plus4WithPrintInterface()
        {
            var @base = new IntFactory();
            var print = new IntPrint();

            var x = @base.Make3Plus4().Eval().Int;
            var s = print.Make3Plus4().Print();

            Assert.Equal(7, x);
            Assert.Equal("3 + 4", s);
        }

        [Fact]
        public void Print2Example()
        {
            var p = new Print2();
            var s = p.Make3Plus4();
            Assert.Equal("3 + 4", s);
        }

        [Theory]
        [InlineData( true,  "True")]
        [InlineData(false, "False")]
        public void PrintBool(bool b, string expected)
        {
            var sut = new IntBoolPrint();
            var actual = sut.Bool(b).Print();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData( true,  true,  true, "if (True) then True else True")]
        [InlineData(false,  true,  true, "if (False) then True else True")]
        [InlineData(false, false,  true, "if (False) then False else True")]
        [InlineData(false, false, false, "if (False) then False else False")]
        public void PrintIff(bool b1, bool b2, bool b3, string expected)
        {
            var sut = new IntBoolPrint();
            var actual =
                sut.Iff(sut.Bool(b1), sut.Bool(b2), sut.Bool(b3)).Print();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrintNestedNonsense()
        {
            var p = new IntBoolPrint();
            var five = p.Lit(5);
            var seven = p.Lit(7);
            var add = p.Add(five, seven);
            var innerIff = p.Iff(add, p.Bool(false), p.Lit(2));
            var outerIff = p.Iff(innerIff, p.Lit(6), p.Bool(true));

            var actual = outerIff.Print();

            var expected =
                "if (if (5 + 7) then False else 2) then 6 else True";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstExampleInSection5Dot3()
        {
            static A exp<A>(IIntAlg<A> v) => v.Add(v.Lit(3), v.Lit(4));
            var p2 = new IntBoolPrint();

            var actual = exp(p2).Print();

            Assert.Equal("3 + 4", actual);
        }

        [Fact]
        public void SecondExampleInSection5Dot3()
        {
            static A exp<A>(IIntAlg<A> v) => v.Add(v.Lit(3), v.Lit(4));
            static A exp2<A>(IIntBoolAlg<A> v) =>
                v.Iff(v.Bool(false), exp(v), v.Lit(0));
            var p = new IntPrint();

            // var _ = exp2(p).Print(); // Type error
            var actual = exp2(new IntBoolPrint()).Print();

            Assert.Equal("if (False) then 3 + 4 else 0", actual);
        }

        [Theory]
        [InlineData(false)]
        [InlineData( true)]
        public void EvalBool(bool expected)
        {
            var sut = new Bool(expected);
            var actual = sut.Eval();
            Assert.Equal(expected, actual.Bool);
        }

        [Theory]
        [InlineData(false, false, false, false)]
        [InlineData( true, false, false, false)]
        [InlineData(false,  true, false, false)]
        [InlineData(false, false,  true,  true)]
        [InlineData( true,  true, false,  true)]
        [InlineData( true,  true,  true,  true)]
        public void EvalIff(bool x, bool y, bool z, bool expected)
        {
            var sut = new Iff(new Bool(x), new Bool(y), new Bool(z));
            var actual = sut.Eval();
            Assert.Equal(expected, actual.Bool);
        }

        [Theory]
        [InlineData("foo", -1)]
        [InlineData("foo", 00)]
        [InlineData("bar", 42)]
        public void AssignLitVar(string name, int expected)
        {
            var sut = new StmtFactory();

            var evaluatedExp = sut.Assign(name, sut.Lit(expected));
            var actual = sut.Var(name);

            Assert.Equal(expected, evaluatedExp.Eval().Int);
            Assert.Equal(expected, actual.Eval().Int);
        }

        [Fact]
        public void FirstExampleInSection6Dot2()
        {
            static E exp<E, S>(IStmtAlg<E, S> v) =>
                v.Assign("x", v.Add(v.Lit(3), v.Lit(4)));
            static S stmt<E, S>(IStmtAlg<E, S> v) =>
                v.Comp(v.Expr(exp(v)), v.Expr(v.Var("x")));
            //S badStmt<E, S>(IStmtAlg<E, S> v) =>
            //    v.Comp(exp(v), v.Var("x")); // Type error

            var factory = new StmtFactory();
            exp(factory).Eval();
            stmt(factory).Eval();

            Assert.Equal(7, factory.Var("x").Eval().Int);
        }

        [Fact]
        public void UseIntBoolFactory2()
        {
            var sut = new IntBoolFactory2();
            var actual =
                sut.Iff(
                    sut.Bool(false),
                    sut.Lit(5),
                    sut.Add(sut.Lit(3), sut.Lit(8)));
            Assert.Equal(11, actual.Eval().Int);
        }

        [Fact]
        public void CombineExample()
        {
            var sut =
                new Combine<int, string>(new EvalIntAlg(), new Print2());

            var actual =
                sut.Add(
                    new Pair<int, string>(  42, "foo"),
                    new Pair<int, string>(1337, "bar"));

            Assert.Equal(1379, actual.TheA);
            Assert.Equal("foo + bar", actual.TheB);
        }

        [Fact]
        public void DebugExample()
        {
            var sut = new Debug();
            var e1 = sut.Lit( 2112);
            var e2 = sut.Add(sut.Lit(90125), sut.Lit(5150));
            var originalOut = Console.Out;
            using var sw = new StringWriter();
            Console.SetOut(sw);
            try
            {
                var actual = sut.Add(e1, e2);

                Assert.Equal(
                    "The first expression 2112 evaluates to 2112" + Environment.NewLine +
                    "The second expression 90125 + 5150 evaluates to 95275" + Environment.NewLine,
                    sw.ToString());
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }

        /* This test attempts to demonstrate that GUnion not only works in its
         * own right, but that it can be used to extend the interfaces it
         * composes.
         * In order to demonstrate that, I've 'extended' the IBoolAlg
         * interface, and then created a new union of interfaces called
         * IIntBoolExtra. The derived class GUnionExtra only has to implement
         * the extra method, while it inherits all the base implementations
         * from GUnion.
         * I think that's the point of that class... */
        [Fact]
        public void GUnionBoolExample()
        {
            var sut = new GUnionExtra<IExp>(
                new BoolExtraFactory(),
                new IntFactory());

            Assert.Equal("foo", sut.ExtraMember());
            Assert.False(sut.Bool(false).Eval().Bool);
            Assert.True(sut.Bool(true).Eval().Bool);
            Assert.True(sut.Iff(
                sut.Bool(false),
                sut.Bool(false),
                sut.Bool(true)).Eval().Bool);
            Assert.Equal(42, sut.Lit(42).Eval().Int);
            Assert.Equal(
                9,
                sut.Add(sut.Lit(3), sut.Lit(6)).Eval().Int);
        }

        private interface IBoolAlgExtra<A> : IBoolAlg<A>
        {
            string ExtraMember();
        }

        private class BoolExtraFactory : BoolFactory, IBoolAlgExtra<IExp>
        {
            public string ExtraMember()
            {
                return "foo";
            }
        }

        private interface IIntBoolExtra<A> : IIntAlg<A>, IBoolAlgExtra<A>
        {
        }

        private class GUnionExtra<A> :
            GUnion<A, IBoolAlgExtra<A>, IIntAlg<A>>, IIntBoolExtra<A>
        {
            private readonly IBoolAlgExtra<A> v1;

            public GUnionExtra(IBoolAlgExtra<A> v1, IIntAlg<A> v2) :
                base(v1, v2)
            {
                this.v1 = v1;
            }

            public string ExtraMember()
            {
                return v1.ExtraMember();
            }
        }

        [Fact]
        public void GCombineExample()
        {
            var sut = new CombineMonoid();

            Assert.Equal(new Pair<int, string>(0, ""), sut.Identity);
            Assert.Equal(new Pair<int, string>(48, "48"), sut.Lit(48));
            Assert.Equal(
                new Pair<int, string>(42, "40 + 2"),
                sut.Add(sut.Lit(40), sut.Lit(2)));

        }

        private interface IIntMonoid<A> : IIntAlg<A>
        {
            A Identity { get; }
        }

        private class EvalIntMonoid : EvalIntAlg, IIntMonoid<int>
        {
            public int Identity => 0;
        }

        private class Print2Monoid : Print2, IIntMonoid<string>
        {
            public string Identity => "";
        }

        private class CombineMonoid :
            GCombine<int, string, IIntMonoid<int>, IIntMonoid<string>>,
            IIntMonoid<Pair<int, string>>
        {
            private readonly IIntMonoid<int> v1;
            private readonly IIntMonoid<string> v2;

            public CombineMonoid() :
                this(new EvalIntMonoid(), new Print2Monoid())
            {
            }

            private CombineMonoid(IIntMonoid<int> v1, IIntMonoid<string> v2) :
                base(v1, v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            public Pair<int, string> Identity => new(v1.Identity, v2.Identity);
        }

        [Fact]
        public void EvalExample()
        {
            var sut = new InvertibleEval(new InvertibleIntVal());

            var actual = sut.Add(sut.Lit(4), sut.Lit(7));
            var inverted = sut.Invert(actual);

            Assert.Equal(11, actual.Int);
            Assert.Equal(-11, inverted.Int);
            Assert.Equal("xxxxxxxxxxx", actual.Repeat('x'));
        }

        private class InvertibleEval :
            Eval<ICharRepeater, IInvertibleVal<ICharRepeater>>,
            IInvertibleVal<ICharRepeater>
        {
            public InvertibleEval(IInvertibleVal<ICharRepeater> valFact) :
                base(valFact)
            {
            }

            public ICharRepeater Invert(ICharRepeater v)
            {
                return valFact.Invert(v);
            }
        }

        private class IntValue : IIntValue
        {
            protected readonly int x;

            public IntValue(int x)
            {
                this.x = x;
            }

            public int Int => x;
        }

        private interface ICharRepeater : IIntValue
        {
            string Repeat(char c);
        }

        private class CharRepeater : IntValue, ICharRepeater
        {
            public CharRepeater(int x) : base(x)
            {
            }

            public string Repeat(char c)
            {
                return new string(c, x);
            }
        }

        private class IntValueIntVal : IIntVal<ICharRepeater>
        {
            public ICharRepeater Lit(int x)
            {
                return new CharRepeater(x);
            }
        }

        private interface IInvertibleVal<A> : IIntVal<A>
        {
            A Invert(A v);
        }

        private class InvertibleIntVal :
            IntValueIntVal, IInvertibleVal<ICharRepeater>
        {
            public ICharRepeater Invert(ICharRepeater v)
            {
                return Lit(-v.Int);
            }
        }
    }
}
