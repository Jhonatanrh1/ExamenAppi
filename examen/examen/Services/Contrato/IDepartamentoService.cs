using examen.Models;
namespace examen.Services.Contrato
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetList();
        Task<Departamento> Get(int idTrab);
        Task<Departamento> Add(Departamento trab);
        Task<bool> Update(Departamento trab);
        Task<bool> Delete(Departamento trab);
    }
}
