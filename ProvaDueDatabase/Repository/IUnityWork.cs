namespace ProvaDueDatabase.Repository
{
    public interface IUnityWork : IDisposable
    {
        public IFiguraRep Figure { get; }
        public IDomandeRep Domande { get; }

        bool Complete();
    }
}
