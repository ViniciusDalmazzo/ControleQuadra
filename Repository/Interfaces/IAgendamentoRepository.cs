using System.Collections.Generic;
using ApiMySql.Model;

namespace ApiMySql.Repository
{
    public interface IAgendamentoRepository
    {
        IEnumerable<Agendamento> GetAll();
        ReserveResponseDTO Add(Agendamento Agendamento);
    }
}