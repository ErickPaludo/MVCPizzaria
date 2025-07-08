using Microsoft.AspNetCore.Mvc;
using MVCPizzaria.DTO;
using MVCPizzaria.Services.Pizzas;

namespace MVCPizzaria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaInterface _pizzaInterface;
        public PizzaController(IPizzaInterface pizzainterface)
        {
            _pizzaInterface = pizzainterface;
        }
        public async Task<IActionResult> Index()
        {
            var pizzas = await _pizzaInterface.GetPizzas();
            return View(pizzas);
        }

        public IActionResult Cadastrar()
        {
            return View();
        } 
        public async Task<IActionResult> Editar(int id)
        {
            var pizza = await _pizzaInterface.GetPizzasPorid(id);
            return View();
        }
        public IActionResult Remover()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(PizzaCriacaoDTO pizza, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                var pizzareal = await _pizzaInterface.CriarPizza(pizza, foto);
                return RedirectToAction("Index", "Pizza");
            }
            else
            {
                return View(pizza);
            }
        }
    }
}
