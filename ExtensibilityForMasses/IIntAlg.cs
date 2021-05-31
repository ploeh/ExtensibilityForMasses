namespace Ploeh.Study.ExtensibilityForMasses
{
    public interface IIntAlg<A>
    {
        A Lit(int x);
        A Add(A e1, A e2);
    }
}