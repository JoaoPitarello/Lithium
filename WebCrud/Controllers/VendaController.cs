using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class VendaController : Controller
    {
        private readonly IConfiguration _configuration;

        public VendaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CadastrarVend()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarVend(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return View(venda);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tb_Venda (data_venda, valor_total, FormaPagamento, qtd, fkclienteid, fkprodutoid) " +
                                 "VALUES (@DataVen, @ValorVen, @FormaVen, @QuanVen, @Fkclienteid, @Fkprodutoid)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@DataVen", venda.DataVen);
                        command.Parameters.AddWithValue("@ValorVen", venda.ValorVen);
                        command.Parameters.AddWithValue("@FormaVen", venda.FormaVen);
                        command.Parameters.AddWithValue("@QuanVen", venda.QuantVen);
                        command.Parameters.AddWithValue("@Fkclienteid", venda.Fkclienteid);
                        command.Parameters.AddWithValue("@Fkprodutoid", venda.Fkprodutoid);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar a venda no banco de dados: " + ex.Message);
                    return View(venda);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
