using Microsoft.EntityFrameworkCore;
using examen.Models;
using examen.Services.Contrato;

namespace examen.Services.Implementacion
{
    
    public class DepartamentoService: IDepartamentoService
    {
        private TrabajadoresPruebaContext _dbContext;

        public DepartamentoService(TrabajadoresPruebaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Departamento>> GetList()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();
                lista = await _dbContext.Departamentos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Departamento> Get(int idTrab)
        {
            try
            {
                Departamento? verdadero = new Departamento();
                verdadero = await _dbContext.Departamentos.FirstOrDefaultAsync();
                return verdadero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Departamento> Add(Departamento trab)
        {
            try
            {
                _dbContext.Departamentos.Add(trab);
                await _dbContext.SaveChangesAsync();
                return trab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Departamento trab)
        {
            try
            {
                _dbContext.Departamentos.Update(trab);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Departamento trab)
        {
            try
            {
                _dbContext.Departamentos.Remove(trab);
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
