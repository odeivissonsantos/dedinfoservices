using DedInfoservices.Helpers;
using DedInfoservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Controllers
{
    public class BaseController : Controller
    {
        public Usuario CurrentUser
        {
            get => Get<Usuario>("CurrentUser");
            set => Set("CurrentUser", value);
        }

        private void Set(string key, object value)
        {
           HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }

        private T Get<T>(string key)
        {
            var value = HttpContext.Session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
