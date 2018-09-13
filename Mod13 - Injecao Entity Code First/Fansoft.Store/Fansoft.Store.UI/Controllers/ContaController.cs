using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Helpers;
using Fansoft.Store.UI.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Security;

namespace Fansoft.Store.UI.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRep = 
            new UsuarioRepository();

        public ActionResult Login(string returnUrl)
        {
            return View(new LoginVM() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var usuario = _usuarioRep.GetbyEmail(model.Email);

            if (usuario==null)
            {
                ModelState.AddModelError("Email", "Email não localizado");
            }
            else
            {
                if (usuario.Senha != model.Senha.Encrypt())
                {
                    ModelState.AddModelError("Senha", "Senha inválida");
                }
            }

            if (ModelState.IsValid)
            {
                var user = JsonConvert.SerializeObject(
                    new UsuarioVM{
                        Id =usuario.Id,
                        Nome = usuario.Nome,
                        Perfil = usuario.Perfil.Nome
                        }
                    );

                FormsAuthentication.SetAuthCookie(user, false);
                if (!string.IsNullOrEmpty(model.ReturnUrl) && 
                    Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Produtos");
            }

            return View(model);

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            _usuarioRep.Dispose();
        }


    }
}