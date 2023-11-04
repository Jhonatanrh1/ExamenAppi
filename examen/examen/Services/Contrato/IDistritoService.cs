using examen.Models;
namespace examen.Services.Contrato
{
    public interface IDistritoService
    {
        Task<List<Distrito>> GetList();
        Task<Distrito> Get(int idTrab);
        Task<Distrito> Add(Distrito trab);
        Task<bool> Update(Distrito trab);
        Task<bool> Delete(Distrito trab);
    }
}
