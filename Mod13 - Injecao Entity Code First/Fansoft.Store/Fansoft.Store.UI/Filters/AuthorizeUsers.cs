using Fansoft.Store.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Filters
{
    public class AuthorizeUsers:AuthorizeAttribute
    {

        private readonly List<string> _perfis = new List<string>();

        public AuthorizeUsers(string perfis)
        {
            //ex: Admin,User
            _perfis = perfis.Split(',').ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var user =
                    JsonConvert.DeserializeObject<UsuarioVM>(httpContext.User.Identity.Name);

            if(user!=null && _perfis.Contains(user.Perfil))
            {
                return true;
            }

            return false;
        }


    }
}
