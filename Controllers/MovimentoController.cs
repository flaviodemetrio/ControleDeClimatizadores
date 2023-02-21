using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
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

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Movimentos.OrderBy(r => r.TipoMovimento).AsNoTracking().ToListAsync());
        //}

        public async Task<IActionResult> Saida()
        {
            var applicationDbContext = _context.Movimentos.Include(m => m.cliente).Where(m => m.TipoMovimento == "saida");
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SaidaDetalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentoModel =  await _context.Movimentos
                .Include(m => m.cliente)
                .Include(m => m.EquipamentosModel)
                .Where(m => m.TipoMovimento == "saida")
                .FirstAsync(m => m.IdMovimento == id);


            if ( movimentoModel== null)
            {
                return NotFound();
            }

            return View(movimentoModel);
        }

        //public async Task<IActionResult> NovaSaida()
        //public async Task<IActionResult> Entrada()
        //public async Task<IActionResult> NovaEntrada()


    }




}