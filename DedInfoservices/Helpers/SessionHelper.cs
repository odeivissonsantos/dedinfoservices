using DedInfoservices.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessionHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Usuario CurrentUser()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CreateCurrentUser(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("CurrentUser", valor);
        }

        public void KillCurrentUser()
        {
            _httpContext.HttpContext.Session.Remove("CurrentUser");
        }

        public HttpContext Current => _httpContext != null ? _httpContext.HttpContext : null;
    }
}
