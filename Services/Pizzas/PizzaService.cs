using Microsoft.EntityFrameworkCore;
using MVCPizzaria.Data;
using MVCPizzaria.DTO;
using MVCPizzaria.Models;
using System.Threading.Tasks;

namespace MVCPizzaria.Services.Pizzas
{
    public class PizzaService : IPizzaInterface
    {
        private readonly AppDbContext _context;
        private readonly string _sistema;
        public PizzaService(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;
            _sistema = sistema.WebRootPath;
        }
        public async Task<PizzaModel> CriarPizza(PizzaCriacaoDTO pizza, IFormFile foto)
        {
            try
            {
                var nomeCaminhoImagem = GeraCaminhoArquivo(foto);
                var pizzareal = new PizzaModel
                {
                    Capa = nomeCaminhoImagem.Result,
                    Descricao = pizza.Descricao,
                    Sabor = pizza.Sabor,
                    Valor = pizza.Valor
                };
                 _context.Pizzas.Add(pizzareal);
                await _context.SaveChangesAsync();
                return pizzareal;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a pizza", ex);
            }
        }

        public async Task<IEnumerable<PizzaModel>> GetPizzas()
        {
           return await _context.Pizzas.ToListAsync();
        }

        public async Task<PizzaModel> GetPizzasPorid(int id)
        {

            return await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
        }

        private async Task<string> GeraCaminhoArquivo(IFormFile foto)
        {
            var codunico = Guid.NewGuid().ToString();
            var nomeCaminhoImagem = foto.FileName.Replace(" ", "").ToLower() + codunico + ".png";
            var caminhoImgSalva = _sistema + "\\Imagens\\";

            if (!Directory.Exists(caminhoImgSalva))
            {
                Directory.CreateDirectory(caminhoImgSalva);
            }
            using(var stream = File.Create(caminhoImgSalva + nomeCaminhoImagem))
            {
               foto.CopyToAsync(stream).Wait();
            }
            return nomeCaminhoImagem;
        }
    }
}
