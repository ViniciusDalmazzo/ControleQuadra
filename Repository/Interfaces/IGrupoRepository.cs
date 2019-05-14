using System.Collections.Generic;
using ApiMySql.Model;

namespace ApiMySql.Repository
{
    public interface IGrupoRepository
    {
        IEnumerable<Grupo> GetAll();
        void Add(Grupo Grupo);
    }
}