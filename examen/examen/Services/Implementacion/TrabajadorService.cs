using Microsoft.EntityFrameworkCore;
using examen.Models;
using examen.Services.Contrato;

namespace examen.Services.Implementacion
{
    public class TrabajadorService:ITrabajadoresService
    {
        private TrabajadoresPruebaContext _dbContext;
        public TrabajadorService(TrabajadoresPruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Trabajador>> GetList()
        {
            try
            {
                List<Trabajador> lista = new List<Trabajador>();
                lista = await _dbContext.Trabajadores.Include(d=>d.IdDepartamentoNavigation).Include(p=>p.IdProvinciaNavigation).Include(di=>di.IdDistritoNavigation).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Trabajador> Get(int idTrab)
        {
            try
            {
                Trabajador? verdadero = new Trabajador();
                verdadero = await _dbContext.Trabajadores.Include(d => d.IdDepartamentoNavigation).Include(p => p.IdProvinciaNavigation).Include(di => di.IdDistritoNavigation).Where(t=>t.Id==idTrab).FirstOrDefaultAsync();
                return verdadero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Trabajador> Add(Trabajador trab)
        {
            try
            {
                _dbContext.Trabajadores.Add(trab);
                await _dbContext.SaveChangesAsync();
                return trab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Trabajador trab)
        {
            try
            {
                _dbContext.Trabajadores.Update(trab);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Trabajador trab)
        {
            try
            {
                _dbContext.Trabajadores.Remove(trab);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
       
    }
}
