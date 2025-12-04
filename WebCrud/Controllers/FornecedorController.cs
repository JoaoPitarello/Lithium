using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IConfiguration _configuration;

        public FornecedorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CadastrarForn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarForn(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return View(fornecedor);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO tbFornecedor (nome, endereco, telefone, email) " +
                                 "VALUES (@Nome, @Endereco, @Telefone, @Email)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@Nome", fornecedor.NomeFor);
                        command.Parameters.AddWithValue("@Endereco", fornecedor.EnderecoFor);
                        command.Parameters.AddWithValue("@Telefone", fornecedor.TelefoneFor);
                        command.Parameters.AddWithValue("@Email", fornecedor.EmailFor);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o fornecedor no banco de dados: " + ex.Message);
                    return View(fornecedor);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
