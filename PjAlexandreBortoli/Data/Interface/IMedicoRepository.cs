using PjAlexandreBortoli.Models;



namespace PjAlexandreBortoli.Data.Interface
{
    public interface IMedicoRepository
    {


        public Medico? GetMedicoById(int id);
        public IQueryable<Medico>? GetMedicos();
        public Medico? Update(Medico? m);
        public Medico? Delete(int id);
        public Medico? Create(Medico m);
    }
}
