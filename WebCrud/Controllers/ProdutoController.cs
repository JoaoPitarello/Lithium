using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProdutoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbProduto (Prodnome, quant_estoque, valor_unitario, valor_metro, Proddescr) " +
                                 "VALUES (@Prodnome, @QuantEstoque, @ValorUnitario, @ValorMetro, @Proddescr)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        // Mapeamento dos parâmetros (Cuidado com a conversão de Decimal para MySQL)
                        command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
                        command.Parameters.AddWithValue("@QuantEstoque", produto.Quant_estoque);
                        command.Parameters.AddWithValue("@ValorUnitario", produto.Valor_unitario);
                        command.Parameters.AddWithValue("@ValorMetro", produto.Valor_metro);
                        command.Parameters.AddWithValue("@Proddescr", produto.Proddescr);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o produto: " + ex.Message);
                    return View(produto);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}