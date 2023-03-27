using API_Priori.DTOs;
using API_Priori.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_Priori.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<ClienteDTO> _userManager;
        private readonly SignInManager<ClienteDTO> _signInManager;

        public AutorizaController(SignInManager<ClienteDTO> signInManager, UserManager<ClienteDTO> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Create(ClienteDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                ClienteDTO appUser = new ClienteDTO
                {
                    UserName = user.Nome,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Senha);

                if (!result.Succeeded)
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);

                return Ok();
            }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] ClienteDTO clienteDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(clienteDTO.Email,
                clienteDTO.Senha, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login inválido....");
                return BadRequest(ModelState);
            }
        }
    }
 }

