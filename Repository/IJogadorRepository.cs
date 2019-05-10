using System.Collections.Generic;
using ApiMySql.Model;

namespace ApiMySql.Repository
{
    public interface IJogadorRepository
    {
        IEnumerable<Jogador> GetAll();
        void Add(Jogador jogador);
    }
}