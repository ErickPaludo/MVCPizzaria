using MVCPizzaria.DTO;
using MVCPizzaria.Models;

namespace MVCPizzaria.Services.Pizzas
{
    public interface IPizzaInterface
    {
        Task<PizzaModel> CriarPizza(PizzaCriacaoDTO pizza, IFormFile foto);
        Task<IEnumerable<PizzaModel>> GetPizzas();
        Task<PizzaModel> GetPizzasPorid(int id);
    }
}
