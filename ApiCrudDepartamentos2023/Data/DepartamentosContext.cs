using ApiCrudDepartamentos2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudDepartamentos2023.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
