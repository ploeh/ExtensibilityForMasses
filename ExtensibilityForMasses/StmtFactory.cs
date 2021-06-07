using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public class StmtFactory : IntBoolFactory, IStmtAlg<IExp, IStmt>
    {
        private readonly Dictionary<string, IValue> map;

        public StmtFactory()
        {
            map = new Dictionary<string, IValue>();
        }

        public IExp Var(string x)
        {
            return new VarExp(map, x);
        }

        private class VarExp : IExp
        {
            private readonly IDictionary<string, IValue> map;
            private readonly string x;

            public VarExp(IDictionary<string, IValue> map, string x)
            {
                this.map = map;
                this.x = x;
            }

            public IValue Eval()
            {
                return map[x];
            }
        }

        public IExp Assign(string x, IExp e)
        {
            return new AssignExp(map, x, e);
        }

        private class AssignExp : IExp
        {
            private readonly IDictionary<string, IValue> map;
            private readonly string x;
            private readonly IExp e;

            public AssignExp(IDictionary<string, IValue> map, string x, IExp e)
            {
                this.map = map;
                this.x = x;
                this.e = e;
            }

            public IValue Eval()
            {
                var value = e.Eval();
                map[x] = value;
                return value;
            }
        }

        public IStmt Comp(IStmt e1, IStmt e2)
        {
            throw new NotImplementedException();
        }

        public IStmt Expr(IExp e)
        {
            throw new NotImplementedException();
        }
    }
}
