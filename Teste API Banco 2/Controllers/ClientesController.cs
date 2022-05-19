using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_API_Banco_2.Business;
using Teste_API_Banco_2.Data;

using Teste_API_Banco_2.Models;
using Teste_API_Banco_2.Repositories;

namespace Teste_API_Banco_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository repository;
        private static List<TabCliente> clientesLista = new List<TabCliente>();
        private AppDbContext appDbContext;

        public ClientesController(IClienteRepository _context)
        {
            repository = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabCliente>>> GetCliente()
        {
            var clientes = await repository.GetAll();

            if (clientes == null)
            {
                return BadRequest();
            }
            return Ok(clientes.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TabCliente>> GetCliente(int id)
        {
            var cliente = await repository.GetById(id);

            if (cliente == null)
            {
                return NotFound("Cliente nao encontrado pelo ID");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] TabCliente clienteDTO)
        { 
            if (clienteDTO != null)
            {

                TabCliente cliente = new TabCliente
                {
                    Nome = clienteDTO.Nome,
                    Idade = clienteDTO.Idade,
                    Saldo = 0,
                    Ativo = true,

                };
                await repository.Insert(cliente);
                return CreatedAtAction(nameof(GetCliente), new { Id = cliente.IdCliente }, cliente);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, TabCliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest($"O código do Cliente {id} não confere");
            }

            try
            {
                await repository.Update(id, cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização Cliente realizada com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TabCliente>> DeleteCliente(int id)
        {
            var cliente = await repository.GetById(id);
            if (cliente == null)
            {
                return NotFound($"Produto de {id} foi não encontrado");
            }

            await repository.Delete(id);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Deposito([FromBody] TabCliente cliente, float valorDeposito)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente é Vazio");
            }
            else
            {
                OperacaoBancaria operacoes = new OperacaoBancaria();
                operacoes.Deposito(valorDeposito);
            }
            await repository.Insert(cliente);

            return CreatedAtAction(nameof(GetCliente), new { Id = cliente.IdCliente }, cliente);
        }

        //[HttpPost]
        /* public async Task<ActionResult> Transfere([FromBody] string clienteTitular, float valorTransferencia, string clienteRecebe)
         {
             OperacaoBancaria operacoes = new OperacaoBancaria();

         }*/

        [Route("id/Deposito")]
        [HttpPost("{id}")]
        public IActionResult RealizarDeposito( /*string nome,*/ int id, [FromBody] TabCliente clienteAtualiza, float ValorDeposito)
        {
            TabCliente cliente = appDbContext.TabCliente.FirstOrDefault(cliente => cliente.IdCliente == id);
            OperacaoBancaria operacaoBancaria = new OperacaoBancaria();
            if (cliente != null && operacaoBancaria.Deposito(ValorDeposito))
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound();
            }

        }

    }
}
