using ApiCrudDepartamentos2023.Models;
using ApiCrudDepartamentos2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudDepartamentos2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Departamento>> GetDepartamentos()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return departamentos;
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> FindDepartamento(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return departamento;
        }

        [HttpGet]
        [Route("[action]/{localidad}")]
        public ActionResult<List<Departamento>> FindDepartamentosLocalidad(string localidad)
        {
            List<Departamento> departamentos = 
                this.repo.GetDepartamentosLocalidad(localidad);
            return departamentos;
        }

        //VAMOS A TENER DOS METODOS PARA INSERTAR
        //EL PRIMER METODO IRAN LOS VALORES POR URL
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task InsertarDepartamento
            (int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
        }

        //EL SEGUNDO METODO RECIBIRA EL DEPARTAMENTO POR BODY
        //ESTE METODO ES EL QUE TIENE POR DEFECTO CUALQUIER CONTROLLER
        //PARA POST, POR LO QUE NO HAY QUE UTILIZAR Route
        [HttpPost]
        public async Task InsertarDepartamento(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
        }

        //EL METODO PUT POR DEFECTO TAMBIEN RECIBE UN OBJETO
        [HttpPut]
        public async Task UpdateDepartamento(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
        }

        //EL METODO DELETE POR DEFECTO RECIBE UN {ID}
        [HttpDelete("{id}")]
        public async Task DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
        }
    }
}
