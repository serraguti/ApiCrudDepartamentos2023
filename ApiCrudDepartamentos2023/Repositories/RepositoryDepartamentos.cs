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

        public async Task InsertDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            Departamento departamento = this.FindDepartamento(id);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento departamento = this.FindDepartamento(id);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
