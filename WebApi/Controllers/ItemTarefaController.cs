using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTarefaController : ControllerBase
    {
        private readonly InterfaceItemTarefa _itemTarefa;

        public ItemTarefaController(InterfaceItemTarefa itemTarefa)
        {
            _itemTarefa = itemTarefa;
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> AdicionarItem(ItemTarefa item)
        {
            if(string.IsNullOrEmpty(item.Nome))
            {
                return BadRequest("Nome do item não pode ser vazio!");
            }

            await _itemTarefa.Adicionar(item);

            return Ok(item);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> AtualizarItem(ItemTarefa item)
        {
            if(item != null)
            {
                await _itemTarefa.Atualizar(item);
            }

            return Ok(item);
        }

        [HttpDelete("Excluir")]
        public async Task<ActionResult> ExcluirItem(ItemTarefa item)
        {
            if(item != null)
            {
                await _itemTarefa.Excluir(item);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("{id:int}")]
        public async Task<ItemTarefa> BuscarPorCodigoItem(int id)
        {
            return await _itemTarefa.BuscarPorCodigo(id);
        }

        [HttpGet("TodosItens")]
        public async Task<List<ItemTarefa>> ListarTodosItem()
        {
            return await _itemTarefa.ListarTudo();
        }
    }
}
