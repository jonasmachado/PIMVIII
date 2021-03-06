﻿using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Repositorio.Context;
using System.Linq;

namespace MyPOS.Repositorio.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public Usuario Login(string login, string senha)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Usuario>().FirstOrDefault(p => p.Email == login && p.Senha == senha);
            }
        }

        public Usuario ObterPorLogin(string login)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Usuario>().FirstOrDefault(p => p.Email == login);
            }
        }
        public Usuario ObterPorId(int id)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Usuario>().FirstOrDefault(p => p.Id_Usuario == id);
            }
        }
    }
}
