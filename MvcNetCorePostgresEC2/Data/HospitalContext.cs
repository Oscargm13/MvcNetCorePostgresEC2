using Microsoft.EntityFrameworkCore;
using MvcNetCorePostgresEC2.Models;

namespace MvcNetCorePostgresEC2.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options): base(options)
        {

        }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
