using examen.Models;
namespace examen.Services.Contrato
{
    public interface IProvinciaService
    {
        Task<List<Provincia>> GetList();
        Task<Provincia> Get(int idTrab);
        Task<Provincia> Add(Provincia trab);
        Task<bool> Update(Provincia trab);
        Task<bool> Delete(Provincia trab);
    }
}
