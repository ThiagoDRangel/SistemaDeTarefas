using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController (ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefas = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel TarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(TarefaModel);

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel TarefaModel, int id)
        {
            TarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(TarefaModel, id);

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Deletar(int id)
        {
            bool tarefaDeletado = await _tarefaRepositorio.Apagar(id);

            return Ok(tarefaDeletado);
        }
    }
}