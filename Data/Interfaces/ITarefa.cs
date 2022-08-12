using Data.Entities;

namespace Data.Interfaces
{
    public interface ITarefa : IGeneric<Tarefa>
    {
        Task AdicionarTarefa(Tarefa Objeto);
        Task<Tarefa> BuscarTarefa(int Id);
        Task<List<Tarefa>> ListarTarefas();
    }
}
