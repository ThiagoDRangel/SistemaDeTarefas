using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        public readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();

        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioId = await BuscarPorId(id);

            if(usuarioId == null)
            {
                throw new Exception($"Usuario do ID: {id} não foi encontrado");
            }
            usuarioId.Nome = usuario.Nome;
            usuarioId.Email = usuario.Email;
            _dbContext.Usuarios.Update(usuarioId);
            await _dbContext.SaveChangesAsync();

            return usuarioId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioId = await BuscarPorId(id);

            if(usuarioId == null)
            {
                throw new Exception($"Usuario do ID: {id} não foi encontrado");
            }
            _dbContext.Usuarios.Remove(usuarioId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }

}