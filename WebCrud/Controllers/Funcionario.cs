using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IConfiguration _configuration;

        public FuncionarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CadastrarFun()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarFun(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return View(funcionario);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbFuncionario (salario, nome, endereco, telefone, email) " +
                                 "VALUES (@Salariofun, @Nomefun, @Enderecofun, @Telefonefun, @Emailfun)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@Salariofun", funcionario.Salariofun);
                        command.Parameters.AddWithValue("@Nomefun", funcionario.Nomefun);
                        command.Parameters.AddWithValue("@Enderecofun", funcionario.Enderecofun);
                        command.Parameters.AddWithValue("@Telefonefun", funcionario.Telefonefun);
                        command.Parameters.AddWithValue("@Emailfun", funcionario.Emailfun);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o funcionário no banco de dados: " + ex.Message);
                    return View(funcionario);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}