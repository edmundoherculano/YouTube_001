using MeuApp.Data;
using MeuApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuApp.Controllers
{
    public class ProdutosController : Controller
    {
        // injeção de dependência
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // injeção de dependência




        // C
        [HttpGet] // exibir o formulário
        public IActionResult Cadastrar()
        {
            return View(new ProdutoModel());
        }
        [HttpPost] // posta o formulário no Banco de Dados
        public async Task<IActionResult> Cadastrar([FromForm] ProdutoModel dados)
        {
            //acessar o BD e na tabela específica adicionar os dados recebidos do formulário
            await _context.Produtos.AddAsync(dados);

            //salvar dos dados no BD
            await _context.SaveChangesAsync();

            //retornar uma view (página)
            return RedirectToAction(nameof(Listagem));
        }





        // R
        public async Task<IActionResult> Listagem()
        {
            //acessar o BD e na tabela específica gerar uma lista dos dados
            var dados = await _context.Produtos
                .OrderBy(x => x.NomeProduto)
                .AsNoTracking()
                .ToListAsync();

            //retornar a view com os dados
            return View(dados);
        }




        // U
        [HttpGet] // exibir o formulário
        public async Task<IActionResult> Atualizar(int id)
        {
            //acessar o BD e na tabela específica e encontrar o registro com o id recebido
            var registro = await _context.Produtos.FindAsync(id);

            //retornar a view com dos dados do registro encontrado
            return View(registro);
        }
        [HttpPost] // posta o formulário no Banco de Dados
        public async Task<IActionResult> Atualizar(int id, [FromForm] ProdutoModel dados)
        {
            //acessar o BD e na tabela específica atualizar os dados recebidos do formulário
            _context.Produtos.Update(dados);

            //salvar dos dados no BD
            await _context.SaveChangesAsync();

            //retornar uma view (página)
            return RedirectToAction(nameof(Listagem));
        }





        // D
        [HttpGet] // exibir o formulário
        public async Task<IActionResult> Excluir(int? id)
        {
            //acessar o BD e na tabela específica e encontrar o registro com o id recebido
            var registro = await _context.Produtos.FindAsync(id);

            //retornar a view com dos dados do registro encontrado
            return View(registro);
        }
        [HttpPost] // posta o formulário no Banco de Dados
        public async Task<IActionResult> Excluir(int id)
        {
            //acessar o BD e na tabela específica e encontrar o registro com o id recebido
            var registro = await _context.Produtos.FindAsync(id);

            //excluir o registro
            _context.Produtos.Remove(registro);

            //salvar dos dados no BD
            await _context.SaveChangesAsync();

            //retornar uma view (página)
            return RedirectToAction(nameof(Listagem));
        }


    }
}
