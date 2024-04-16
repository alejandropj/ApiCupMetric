using ApiCupMetric.Models;
using ApiCupMetric.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCupMetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private RepositoryIngredientes repo;
        public IngredientesController (RepositoryIngredientes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingrediente>>> 
            GetIngredientes() 
        {
            return await this.repo.GetIngredientesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>>
            FindIngrediente(int id)
        {
            return await this.repo.FindIngredienteByIdAsync(id);
        }
    }
}
