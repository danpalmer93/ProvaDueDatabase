using ProvaDueDatabase.Data;
using ProvaDueDatabase.Models;

namespace ProvaDueDatabase.Repository
{
    public class UnitWork : IUnityWork
    {
        private ProvaDueContext _context;

        public UnitWork(ProvaDueContext context)
        {
            _context = context;

            Figure = new FiguraRep(context);
            Domande = new DomandeRep(context);
        }
        public IFiguraRep Figure { get; private set; }

        public IDomandeRep Domande { get; private set; }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
