using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManicura2025V4.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntitybase
    {
        private readonly AppDbContext context;

        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task <bool> Existe (int id)
        {
            bool existe = await context.Set<E>().AnyAsync(e => e.Id == id);
            return existe;
        }

        public async Task<List<E>> SelectListaTurno()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {

                throw err;
            }
            
        }
     
        public async Task<bool> Update(int id, E entidad)
        { 
            if (id != entidad.Id)
            {
                return false;
            }
            var existe = await Existe(id);
            if (!existe) return false;
            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception err)
            {

                throw err;
            }

        }
    }
}
