﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;
using Clases;

namespace tp_api.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        public Usuario GetByOAuth(OAuthUser user)
        {
            var us = _context.Usuarios.Where(x => x.Email == user.Username).FirstOrDefault();
            if(us == null)
            {
                Usuario nuevo = new Usuario();
                nuevo.Email = user.Username;
                nuevo.AccessToken = user.Token.TokenAccess;
                nuevo.RefreshToken = user.Token.Refresh;
                nuevo.TokenExpiration = user.Token.Expires;

                _context.Usuarios.Add(nuevo);
                _context.SaveChanges();
                return nuevo;
            }
            if (us.AccessToken != user.Token.TokenAccess)
            {
                us.AccessToken = user.Token.TokenAccess;
                us.RefreshToken = user.Token.Refresh;
                us.TokenExpiration = user.Token.Expires;
                _context.SaveChanges();
            }

            return us;

        }
    }


}