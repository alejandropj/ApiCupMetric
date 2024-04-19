using ApiCupMetric.Models;
using ApiCupMetric.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCupMetric.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private RepositoryReceta repo;
        public RecetasController(RepositoryReceta repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Receta>>>
            GetRecetas()
        {
            return await this.repo.GetRecetasAsync();
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<int>>
            CountRecetas()
        {
            return await this.repo.CountRecetasAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Receta>>
            FindReceta(int id)
        {
            return await this.repo.FindRecetaByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult>
            CreateReceta(RecetaIngrediente recetaIngredientes)
        {
            await this.repo.CreateRecetaAsync(recetaIngredientes.Receta
                ,recetaIngredientes.IdIngredientes,recetaIngredientes.Cantidad);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>
            UpdateIngrediente(Receta receta)
        {
            await this.repo.UpdateRecetaAsync(receta);
            return Ok();
        }
        [HttpDelete("{idreceta}")]
        public async Task<ActionResult>
            DeleteIngrediente(int idreceta)
        {
            await this.repo.DeleteRecetaAsync(idreceta);
            return Ok();
        }
    }
}
