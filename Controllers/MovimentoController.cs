using System;
using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly EstoqueWebContext _context;

        public MovimentoController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Saida()
        {
            var applicationDbContext = _context.Movimentos
                .Include(m => m.cliente)
                .Where(m => m.TipoMovimento == "saida");
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SaidaDetalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentoModel = await _context.Movimentos
                .Include(m => m.cliente)
                .Include(m => m.EquipamentosModel)
                .Where(m => m.TipoMovimento == "saida")
                .FirstAsync(m => m.MovimentoId == id);


            if (movimentoModel == null)
            {
                return NotFound();
            }

            return View(movimentoModel);
        }
        public IActionResult SaidaNovo()
        {

            ViewData["viewdatacliente"] = new SelectList(_context.Clientes, "ClienteId", "RazaoSocial");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaidaNovo(MovimentoModel movimentoModel)
        {
            movimentoModel.TipoMovimento = "saida";
            movimentoModel.DataMovimento = DateTime.Now.ToString("dd/MM/yyyy");

            _context.Movimentos.Add(movimentoModel);

            if (await _context.SaveChangesAsync() > 0)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Movimento de saída adicionado com sucesso.");
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Erro ao adicionar movimento.", TipoMensagem.Erro);
            }

            return RedirectToAction(nameof(Saida));
        }

        //public async Task<IActionResult> NovaSaida()
        //public async Task<IActionResult> Entrada()
        //public async Task<IActionResult> NovaEntrada()


    }




}