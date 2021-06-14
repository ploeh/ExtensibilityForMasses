using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IPartitionFactory<E> : IBatchFactory<E>
    {
        E Other(object external, params E[] subs);
        E DynamicCall(E target, string method, IEnumerable<E> args);
        E Mobile(string type, object obj, E exp);
    }
}
