using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class TarefaRepositorio: ITarefaRepositorio
    {
        public readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(u => u.Usuario)
                .ToListAsync();

        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaId = await BuscarPorId(id);

            if(tarefaId == null)
            {
                throw new Exception($"tarefa do ID: {id} não foi encontrado");
            }
            tarefaId.Nome = tarefa.Nome;
            tarefaId.Descricao = tarefa.Descricao;
            tarefaId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaId);
            await _dbContext.SaveChangesAsync();

            return tarefaId;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaId = await BuscarPorId(id);

            if(tarefaId == null)
            {
                throw new Exception($"tarefa do ID: {id} não foi encontrado");
            }
            _dbContext.Tarefas.Remove(tarefaId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }

}