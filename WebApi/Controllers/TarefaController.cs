using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefa _tarefa;
        private readonly IMapper _mapper;

        public TarefaController(ITarefa tarefa, IMapper mapper)
        {
            _tarefa = tarefa;
            _mapper = mapper;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> AdicionarTarefa(TarefaViewModel tarefa)
        {
            var tarefaMap = _mapper.Map<Tarefa>(tarefa);

            await _tarefa.AdicionarTarefa(tarefaMap);

            return Ok(tarefa);
        }

        [HttpDelete("Excluir")]
        public async Task<ActionResult> Excluir(int id)
        {
            await _tarefa.Excluir(new Tarefa { Id = id });

            return Ok();
        }

        [HttpGet("Buscar/{id:int}")]
        public async Task<TarefaViewModel> BuscarTarefa(int id)
        {
            var tarefa = await _tarefa.BuscarTarefa(id);
            var clienteMap = _mapper.Map<TarefaViewModel>(tarefa);
            return clienteMap;
        }

        [HttpGet("TodasTarefas")]
        public async Task<List<TarefaViewModel>> ListarTarefa()
        {
            var tarefa = await _tarefa.ListarTarefas();
            var clienteMap = _mapper.Map<List<TarefaViewModel>>(tarefa);
            return clienteMap;
        }
    }
}
