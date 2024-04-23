using ApiCupMetric.Models;
using ApiCupMetric.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCupMetric.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private RepositoryUsers repo;
        public UserController(RepositoryUsers repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>>
            Users()
        {
            return await this.repo.GetUsersAsync();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<int>>
            CountUsers()
        {
            return await this.repo.CountUsersAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>>
            FindUser(int id)
        {
            return await this.repo.FindUserByIdAsync(id);
        }
/*        [HttpGet("[action]")]
        public async Task<ActionResult<User>>
            LoginUser(LoginModel login)
        {
            return await this.repo.LoginUserAsync(login.Email, login.Password);
        }*/
        [HttpPost]
        public async Task<ActionResult>
            RegisterUser(UserReg user)
        {
            await this.repo.RegisterUserAsync(user.Nombre, user.Email, user.Password);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult>
            UpdateUser(UserReg user)
        {
            await this.repo.UpdateUserAsync(user.IdUsuario,user.Nombre
                ,user.Email,user.Password);
            return Ok();
        }
        [HttpDelete("{iduser}")]
        public async Task<ActionResult>
            DeleteUser(int iduser)
        {
            await this.repo.DeleteUserAsync(iduser);
            return Ok();
        }
    }
}
