using ApiCrudDepartamentos2023.Data;
using ApiCrudDepartamentos2023.Models;

namespace ApiCrudDepartamentos2023.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int iddepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == iddepartamento
                           select datos;
            return consulta.FirstOrDefault();
        }

        public List<Departamento> GetDepartamentosLocalidad(string localidad)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.Localidad == localidad
                           select datos;
            return consulta.ToList();
        }
    }
}
