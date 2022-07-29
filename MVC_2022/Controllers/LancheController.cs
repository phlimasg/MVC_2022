using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repositories.Interfaces;
using MVC_2022.ViewModels;

namespace MVC_2022.Controllers
{
    public class LancheController : Controller
    {
        protected readonly ILancheRepository _ilancheRepository;

        public LancheController(ILancheRepository ilancheRepository)
        {
            _ilancheRepository = ilancheRepository;
        }

        public IActionResult Index(string categoria)
        {
            ViewData["Title"] = "Todos os Lanches";
            ViewData["Data"] = DateTime.Now;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _ilancheRepository.Lanches.OrderBy(l => l.id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {                
                lanches = _ilancheRepository.Lanches
                        .Where(l => l.Categoria.Nome.Equals(categoria))
                        .OrderBy(l => l.Nome);
                
                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lancheListViewModel);
            /*var lanches = _ilancheRepository.Lanches;
            return View(lanches);*/
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: testController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lanche lanche)
        {
            try
            {
                //_ilancheRepository.Lanches.Add(lanche);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
