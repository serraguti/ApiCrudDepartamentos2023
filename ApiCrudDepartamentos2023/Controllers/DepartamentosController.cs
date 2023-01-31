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
    }
}
