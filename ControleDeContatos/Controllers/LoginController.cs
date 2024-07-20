using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao,
                               IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado, redirecionar para Home

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarPorLogin(login.UserLogin);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválida. Tente novamente.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Login e/ou senha inválidos. Tente novamente.";
                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenha.Email, redefinirSenha.UserLogin);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sistema de contatos - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o email. Por favor, tente novamente.";
                        }

                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
    }
}
