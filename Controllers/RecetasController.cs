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
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<RecetaIngredienteValoracion>>>
            RecetasFormatted()
        {
            return await this.repo.GetRecetasFormattedAsync();
        }           
        [HttpGet("[action]/{idcategoria}")]
        public async Task<ActionResult<List<RecetaIngredienteValoracion>>>
            FilterReceta(int idcategoria)
        {
            return await this.repo.FilterRecetaByCategoriaAsync(idcategoria);
        }        
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Categoria>>>
            Categorias()
        {
            return await this.repo.GetCategoriasAsync();
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
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<RecetaIngredienteValoracion>>
            RecetaFormatted(int id)
        {
            return await this.repo.FindRecetaFormattedAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult>
            CreateReceta(RecetaIngrediente recetaIngredientes)
        {
            await this.repo.CreateRecetaAsync(recetaIngredientes.Receta
                ,recetaIngredientes.IdIngredientes,recetaIngredientes.Cantidad);
            return Ok();
        }        
        [HttpPost("[action]")]
        public async Task<ActionResult>
            Valoracion(Valoracion valoracion)
        {
            await this.repo.PostValoracionAsync(valoracion.IdReceta,
                valoracion.IdUsuario, valoracion.NumValoracion);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>
            UpdateIngrediente(Receta receta)
        {
            await this.repo.UpdateRecetaAsync(receta);
            return Ok();
        }        
        [HttpPut("[action]/{idreceta}")]
        public async Task<ActionResult>
            AddVisit(int idreceta)
        {
            await this.repo.AddVisitRecetaAsync(idreceta);
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
