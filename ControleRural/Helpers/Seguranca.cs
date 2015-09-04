using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using ControleRural.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
namespace ControleRural.Helpers
{
    public static class Seguranca
    {
        public static void GerearSessaoDeUsuario(Usuario usuarioLogado)
        {
            var claims = new List<Claim>
            {
                new Claim("ID",usuarioLogado.ID),
                new Claim(ClaimTypes.Name,usuarioLogado.Nome),
                new Claim(ClaimTypes.Email, usuarioLogado.Email),
                new Claim(ClaimTypes.Role,usuarioLogado.Permissao)
            };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            HttpContext.Current.Request.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
           
        }

        public static void DestruirSessaoDeUsuario()
        {
            var ctx = HttpContext.Current.Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();
        }

        public static Usuario Usuario()
        {

            var ctx = (OwinContext)HttpContext.Current.Request.GetOwinContext();
            var user = ctx.Authentication.User;
            if (user.FindFirst("Id")==null)
            {
                return new Usuario();
            }
            var usuario = new Usuario()
            {
                ID = user.FindFirst("ID").Value,
                Email = user.FindFirst(ClaimTypes.Email).Value,
                Nome = user.FindFirst(ClaimTypes.Name).Value,
                Permissao = user.FindFirst(ClaimTypes.Role).Value
               
                
            };
            return usuario;
        }
    }

}