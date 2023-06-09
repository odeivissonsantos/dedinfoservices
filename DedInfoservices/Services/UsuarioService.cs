﻿using DedInfoservices.Context;
using DedInfoservices.Filters.Usuario;
using DedInfoservices.Models;
using DedInfoservices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DedInfoservices.Services
{
    public class UsuarioService
    {
        private readonly DataContext _context;
        private readonly Email _email;

        public UsuarioService(DataContext context, Email email)
        {
            _context = context;
            _email = email;
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuario.ToList();
        }

        public void SalvarUsuario(SalvarUsuarioFilter filter)
        {
            bool novo = true;
            Usuario usuario = new();

            usuario = BuscarUsuario(1, filter.Email);
            if (usuario != null) novo = false;
            if(usuario == null) usuario = new();

            usuario.Nome = filter.Nome;
            usuario.Sobrenome = filter.Sobrenome;
            usuario.Email = filter.Email;
            usuario.Perfil = filter.Perfil;
            
            if (novo)
            {
                usuario.Guuid = Guid.NewGuid().ToString();
                usuario.Senha = filter.Senha;
                _context.Usuario.Add(usuario);
            }
            else
            {
                _context.Usuario.Update(usuario);                   
            }

            _context.SaveChanges();

        }

        public void AlterarSenha(AlterarSenhaFilter filter)
        {
            var usuario = BuscarUsuario(2, filter.Guuid);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            string novaSenhaEncriptada = Hash.SHA512(filter.NovaSenha);
            usuario.Senha = novaSenhaEncriptada;

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario BuscarUsuario(int tipoPesquisa, string parametro)
        {
            //1 - Pesquisa por email; 2 - Pesquisa pelo GUID
            Usuario usuario = new();
            if(tipoPesquisa == 1) usuario = _context.Usuario.Where(x => x.Email == parametro).FirstOrDefault();
            if(tipoPesquisa == 2) usuario = _context.Usuario.Where(x => x.Guuid == parametro).FirstOrDefault();

            return usuario;
        }

        public void ReativarDesativarUsuario(int tipoExecuxao, string guuid)
        {
            //1 - Reativa; 2 - Desativa
            var usuario = BuscarUsuario(2, guuid);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            usuario.Sts_Exclusao = tipoExecuxao == 1 ? false : true;

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
