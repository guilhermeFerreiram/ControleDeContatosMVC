using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                      ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenha alterarSenha)
        {
            try
            {
                Usuario usuario = _sessao.BuscarSessaoUsuario();
                alterarSenha.Id = usuario.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Senha Alterada com sucesso";
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar a senha, tente novamente. Detalhe do erro: {ex.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
