using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class ProducaoController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProducaoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CadastrarProdu()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarProdu(Producao producao)
        {
            if (!ModelState.IsValid)
            {
                return View(producao);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO tbProducao (data_inicio, data_fim, qtd_material, fkfuncionarioid) " +
                                 "VALUES (@IniProdu, @FimProdu, @QtdProdu, @Fkfuncionarioid)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@IniProdu", producao.IniProdu);
                        command.Parameters.AddWithValue("@FimProdu", producao.FimProdu);
                        command.Parameters.AddWithValue("@QtdProdu", producao.QtdProdu);
                        command.Parameters.AddWithValue("@Fkfuncionarioid", producao.Fkfuncionarioid);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar a produção no banco de dados: " + ex.Message);
                    return View(producao);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
