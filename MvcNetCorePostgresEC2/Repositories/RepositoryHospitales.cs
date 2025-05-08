using Microsoft.EntityFrameworkCore;
using MvcNetCorePostgresEC2.Data;
using MvcNetCorePostgresEC2.Models;

namespace MvcNetCorePostgresEC2.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;
        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamento(int idDepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(d => d.IdDepartamento == idDepartamento);
        }

        public async Task InsertDepartamento(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
