using ApiCupMetric.Models;
using ApiCupMetric.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCupMetric.Controllers
{
    [Route("data/[controller]")]
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
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<List<Ingrediente>>> 
            IngredientesMedibles() 
        {
            return await this.repo.GetIngredientesMediblesAsync();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<int>>
            CountIngredientes()
        {
            return await this.repo.CountIngredientesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>>
            FindIngrediente(int id)
        {
            return await this.repo.FindIngredienteByIdAsync(id);
        }        
        [HttpPost]
        public async Task<ActionResult>
            CreateIngrediente(Ingrediente ingrediente)
        {
            await this.repo.CreateIngredienteAsync(ingrediente);
            return Ok();
        }        
        [HttpPut]
        public async Task<ActionResult>
            UpdateIngrediente(Ingrediente ingrediente)
        {
            await this.repo.UpdateIngredienteAsync(ingrediente);
            return Ok();
        }        
        [HttpDelete("{idingrediente}")]
        public async Task<ActionResult>
            DeleteIngrediente(int idingrediente)
        {
            await this.repo.DeleteIngredienteAsync(idingrediente);
            return Ok();
        }
    }
}
