using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Autenticacao;
using Service.Interfaces;

namespace WebApi.Controllers
{
    [Route("account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService<User> _tokenService;
        private readonly ICarregaService<User> _carregaService;
        private readonly IPersistenciaService _persistenciaService;
        public HomeController(ITokenService<User> tokenService, ICarregaService<User> carregaService, IPersistenciaService persistenciaService)
        {
            _tokenService = tokenService;
            _carregaService = carregaService;
            _persistenciaService = persistenciaService;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticacao(User model)
        {
            model.Password = _tokenService.Encrypt(model.Password);
            var user = _carregaService.CarregaPor(model);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
        [HttpPost]
        [Route("registrar")]
        [Authorize]
        public ActionResult<dynamic> Registrar(User model)
        {
            try
            {
                model.Password = _tokenService.Encrypt(model.Password);
                var user = _carregaService.CarregaPor(model);
                if (user == null)
                {
                    if (_persistenciaService.Add(model))
                    {
                        model.Password = "";
                        return Ok(model);
                    }
                    return BadRequest("Erro ao salvar: ");
                }
                return BadRequest("Já existe");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao acessar banco: {e.Message}");
            }
        }

        [HttpPut]
        [Route("atualizar")]
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult<dynamic> Atualizar(User model)
        {
            try
            {
                model.Password = _tokenService.Encrypt(model.Password);
                if (_persistenciaService.Update(model))
                {
                    model.Password = "";
                    return Ok(model);
                }
                return BadRequest("Erro ao salvar: ");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao acessar banco: {e.Message}");
            }
        }
    }
}
