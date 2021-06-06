namespace Ploeh.Study.ExtensibilityForMasses
{
    public class VInt : IValue
    {
        public VInt(int x)
        {
            Int = x;
        }

        public int Int { get; }

        public bool Bool => throw new System.NotImplementedException();
    }
}