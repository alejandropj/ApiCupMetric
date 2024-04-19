using ApiCupMetric.Models;
using ApiCupMetric.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCupMetric.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class UtensilioController : ControllerBase
    {
        private RepositoryUtensilios repo;
        public UtensilioController(RepositoryUtensilios repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Utensilio>>>
            GetUtensilios()
        {
            return await this.repo.GetUtensiliosAsync();
        }
        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult<int>>
            CountUtensilios()
        {
            return await this.repo.CountUtensiliosAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Utensilio>>
            FindUtensilio(int id)
        {
            return await this.repo.FindUtensilioByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult>
            CreateUtensilio(Utensilio utensilio)
        {
            await this.repo.CreateUtensilioAsync(utensilio);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>
            UpdateUtensilio(Utensilio utensilio)
        {
            await this.repo.UpdateUtensilioAsync(utensilio);
            return Ok();
        }
        [HttpDelete("{idutensilio}")]
        public async Task<ActionResult>
            DeleteUtensilio(int idutensilio)
        {
            await this.repo.DeleteUtensilioAsync(idutensilio);
            return Ok();
        }
    }
}
