using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IBatchFactory<E>
    {
        E Var(string name); // Variable reference
        E Data(object value); // Simple constant (number, string, or date)
        E Fun(string var, E body);
        E Prim(Op op, IEnumerable<E> args); // Unary and binary operators
        E Prop(E @base, string field); // Field access
        E Assign(Op op, E target, E source); // Assignment
        E Let(string var, E expression, E body); // Control flow
        E If(E condition, E thenExp, E elseExp);
        E Loop(Op op, string var, E collection, E body);
        E Call(E target, string method, IEnumerable<E> args); // Method invocation
        E In(string location); // Reading and writing forest
        E Out(string location, E expression);
    }
}
