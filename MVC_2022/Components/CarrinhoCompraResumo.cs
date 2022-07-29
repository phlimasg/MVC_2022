using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.ViewModels;

namespace MVC_2022.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoDeCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoDeCompra)
        {
            _carrinhoDeCompra = carrinhoDeCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = new List<CarrinhoCompraItem>
            {
                new CarrinhoCompraItem(),
                new CarrinhoCompraItem()
            };
            _carrinhoDeCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoDeCompra,
                CarrinhoCompraTotal = _carrinhoDeCompra.GetCarrinhoTotal(),
            };
            return View(carrinhoCompraVM);
        }
    }
}
