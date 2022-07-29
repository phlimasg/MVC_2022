using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repositories.Interfaces;
using MVC_2022.ViewModels;

namespace MVC_2022.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRespository;
        private readonly CarrinhoCompra _carrinhoDeCompra;

        

        public CarrinhoCompraController(ILancheRepository lancheRespository, CarrinhoCompra carrinhoDeCompra)
        {
            _lancheRespository = lancheRespository;
            _carrinhoDeCompra = carrinhoDeCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoDeCompra.GetCarrinhoCompraItems();
            
            _carrinhoDeCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoDeCompra,
                CarrinhoCompraTotal = _carrinhoDeCompra.GetCarrinhoTotal(),
            };
            return View(carrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int id)
        {
            var lancheSelecioando = _lancheRespository.Lanches.FirstOrDefault(p => p.id == id);
            if(lancheSelecioando != null) _carrinhoDeCompra.AdicionarAoCarrinho(lancheSelecioando);
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra(int id)
        {
            var lancheSelecioando = _lancheRespository.Lanches.FirstOrDefault(p => p.id == id);
            if (lancheSelecioando != null) _carrinhoDeCompra.RemoverDoCarrinho(lancheSelecioando);
            return RedirectToAction("Index");
        }
    }
}
