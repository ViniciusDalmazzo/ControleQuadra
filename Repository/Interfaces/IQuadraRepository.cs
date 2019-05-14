using System.Collections.Generic;
using ApiMySql.Model;

namespace ApiMySql.Repository
{
    public interface IQuadraRepository
    {
        IEnumerable<Quadra> GetAll();
        void Add(Quadra Quadra);
    }
}