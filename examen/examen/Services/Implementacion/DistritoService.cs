using Microsoft.EntityFrameworkCore;
using examen.Models;
using examen.Services.Contrato;

namespace examen.Services.Implementacion
{
    
    public class DistritoService : IDistritoService
    {
        private TrabajadoresPruebaContext _dbContext;

        public DistritoService(TrabajadoresPruebaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Distrito>> GetList()
        {
            try
            {
                List<Distrito> lista = new List<Distrito>();
                lista = await _dbContext.Distritos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Distrito> Get(int idTrab)
        {
            try
            {
                Distrito? verdadero = new Distrito();
                verdadero = await _dbContext.Distritos.FirstOrDefaultAsync();
                return verdadero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Distrito> Add(Distrito trab)
        {
            try
            {
                _dbContext.Distritos.Add(trab);
                await _dbContext.SaveChangesAsync();
                return trab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Distrito trab)
        {
            try
            {
                _dbContext.Distritos.Update(trab);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Distrito trab)
        {
            try
            {
                _dbContext.Distritos.Remove(trab);
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
