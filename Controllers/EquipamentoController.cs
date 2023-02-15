using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class EquipamentoController: Controller
    {
        private readonly EstoqueWebContext _context;

        public EquipamentoController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipamentos.OrderBy(r => r.Tag).AsNoTracking().ToListAsync());           
        }

        public IActionResult Cadastrar()
        {
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EquipamentoModel equipamentoModel)
        {
               

                _context.Equipamentos.Add(equipamentoModel);
                                         
                
                if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Equipamento cadastrada com sucesso.");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar equipamento.", TipoMensagem.Erro);
                    }
                
                return RedirectToAction(nameof(Index));
        }
     public async Task<IActionResult> Alterar(int? Id)
        {          
           
              if (Id.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(Id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Alterar(ClienteModel clienteModel)
        {
                _context.Clientes.Update(clienteModel);
                // await _context.SaveChangesAsync();                             
                if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Cliente alterado com sucesso.");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar cliente.", TipoMensagem.Erro);
                    }
                
                return RedirectToAction(nameof(Index));
        }

public async Task<IActionResult> Excluir(int? Id)
        {          
           
              if (Id.HasValue)
            {
                var cliente = await _context.Clientes.FindAsync(Id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(ClienteModel clienteModel)
        {
                _context.Clientes.Remove(clienteModel);
                // await _context.SaveChangesAsync();                             
                if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Cliente excluido com sucesso.");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao excluir cliente.", TipoMensagem.Erro);
                    }
                
                return RedirectToAction(nameof(Index));
        }







    }  
}