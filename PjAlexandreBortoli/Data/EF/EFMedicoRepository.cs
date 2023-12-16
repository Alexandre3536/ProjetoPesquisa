using PjAlexandreBortoli.Data;
using PjAlexandreBortoli.Data.Interface;
using PjAlexandreBortoli.Models;
using System.Linq;

namespace PjAlexandreBortoli.Data.EF
{
    public class EFMedicoRepository : IMedicoRepository
    {
        private AppDbContext context;

        public EFMedicoRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Medico? Create(Medico m)
        {
            try
            {
                context.Medicos?.Add(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }

        public Medico? Delete(int id)
        {
            Medico? m = GetMedicoById(id);
            if (m == null)
                return null;

            context.Medicos?.Remove(m);
            context.SaveChanges();

            return m;
        }

        public Medico? GetMedicoById(int id)
        {
            Medico? m =
                context
                    .Medicos?
                    .Where(m => m.Id == id)
                    .FirstOrDefault(); ;

            return m;
        }

        public IQueryable<Medico>? GetMedicos()
        {
            return context.Medicos;
        }

        public Medico? Update(Medico m)
        {
            try
            {
                context.Medicos?.Update(m);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return m;
        }
    }
}
