using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface ISqlTranslation
    {
        void ToSql(StringBuilder sb, IEnumerable<object> @params, Forest data);
        Expression Normalize(ISchema schema, SqlQuery query,
            Expression outerCond, Env env, NormType normType);
        SqlTable GetTable();
        Expression InvertPath(Expression e, Env env, bool fromChild);
        SqlTable GetTableNoJoins(Env env);
        SqlTable GetBase(Env env);
        Expression WithoutTransformations();
        Expression GetTransformations(Expression @base);
        Expression TrimLast(Env env);
    }
}
