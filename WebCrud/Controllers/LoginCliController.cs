using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{
    public class LoginCliController : Controller
    {

        private readonly IConfiguration _configuration;
        public LoginCliController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // exibe o formulário de cadastro
        [HttpGet]
        public IActionResult CadastrarCli() // renomeando de Cadastrar para CadastrarCli
        {
            // O sistema procura por Views/LoginCli/CadastrarCli.cshtml
            return View();
        }

        // processa o cadastro do Cliente
        [HttpPost]
        public IActionResult CadastrarCli(Cliente cliente) // renomeando Cadastrar para CadastrarCli
        {
    
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            // usando essa conexão para garantir uma conexão com o SQL
            using var connection = new MySqlConnection(connectionString);
            {
                connection.Open();

                // comando SQL pras respectivas colunas da nossa tb cliente
                string sql = "INSERT INTO cliente (NomeCli, EmailCli, EnderecoCli, TelefoneCli) " +
                             "VALUES (@NomeCli, @EmailCli, @EnderecoCli, @TelefoneCli)";

                using MySqlCommand command = new MySqlCommand(sql, connection);
                {
                    // parâmetros para o Cliente ser cadastrado
                    command.Parameters.AddWithValue("@NomeCli", cliente.NomeCli);
                    command.Parameters.AddWithValue("@EmailCli", cliente.EmailCli);
                    command.Parameters.AddWithValue("@EnderecoCli", cliente.EnderecoCli);
                    command.Parameters.AddWithValue("@TelefoneCli", cliente.TelefoneCli);

                    command.ExecuteNonQuery();
                }
            }

            // redireciona após o cadastro do cliente
            return RedirectToAction("Index", "Home");
        }
    }
}