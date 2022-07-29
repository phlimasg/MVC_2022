using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;

namespace MVC_2022.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraid { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context) { CarrinhoCompraid = carrinhoId };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.id == lanche.id && s.CarrinhoCompraid == CarrinhoCompraid);
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraid = CarrinhoCompraid,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.id == lanche.id && s.CarrinhoCompraid == CarrinhoCompraid);

            var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ?? (
                CarrinhoCompraItems = _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraid == CarrinhoCompraid)
                .Include(s => s.Lanche)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoitems = _context.CarrinhoCompraItems
                .Where(carrinho => carrinho.CarrinhoCompraid == CarrinhoCompraid);
            _context.CarrinhoCompraItems.RemoveRange(carrinhoitems);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoTotal()
        {
            return _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraid == CarrinhoCompraid)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        }
    }
}
