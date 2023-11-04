using examen.Models;
namespace examen.Services.Contrato
{
    public interface ITrabajadoresService
    {
        Task<List<Trabajador>> GetList();
        Task<Trabajador> Get(int idTrab);
        Task<Trabajador> Add(Trabajador trab);
        Task<bool> Update(Trabajador trab);
        Task<bool> Delete(Trabajador trab);

    }
}
