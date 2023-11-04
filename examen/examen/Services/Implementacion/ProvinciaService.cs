using Microsoft.EntityFrameworkCore;
using examen.Models;
using examen.Services.Contrato;

namespace examen.Services.Implementacion
{
    
    public class ProvinciaService: IProvinciaService
    {
        private TrabajadoresPruebaContext _dbContext;

        public ProvinciaService(TrabajadoresPruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Provincia>> GetList()
        {
            try
            {
                List<Provincia> lista = new List<Provincia>();
                lista = await _dbContext.Provincia.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Provincia> Get(int idTrab)
        {
            try
            {
                Provincia? verdadero = new Provincia();
                verdadero = await _dbContext.Provincia.FirstOrDefaultAsync();
                return verdadero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Provincia> Add(Provincia trab)
        {
            try
            {
                _dbContext.Provincia.Add(trab);
                await _dbContext.SaveChangesAsync();
                return trab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Provincia trab)
        {
            try
            {
                _dbContext.Provincia.Update(trab);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Provincia trab)
        {
            try
            {
                _dbContext.Provincia.Remove(trab);
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
