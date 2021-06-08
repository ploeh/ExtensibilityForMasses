namespace Ploeh.Study.ExtensibilityForMasses
{
    public class BoolFactory : IBoolAlg<IExp>
    {
        public IExp Bool(bool b)
        {
            return new Bool(b);
        }

        public IExp Iff(IExp b, IExp e1, IExp e2)
        {
            return new Iff(b, e1, e2);
        }
    }
}