using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebCrud.Models;


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
        [ValidateAntiForgeryToken] // Adicionado para segurança (boa prática)
        public IActionResult CadastrarCli(Cliente cliente) // renomeando Cadastrar para CadastrarCli
        {
            // impede a execução do SQL se houver campos obrigatórios vazios, etc.
            if (!ModelState.IsValid)
            {
                // se a validação falhar vai retornar a View com as mensagens de erro
                return View(cliente);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            // usando essa conexão para garantir uma conexão com o SQL
            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();

                    // comando SQL pras respectivas colunas da nossa tb cliente
                    string sql = "INSERT INTO tbCliente (NomeCli, EmailCli, EnderecoCli, TelefoneCli) " +
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
                catch (MySqlException ex)
                {
                    // Adicionado: Trativa básica de erro do banco de dados (opcional)
                    ModelState.AddModelError(string.Empty, "Erro ao tentar registrar no banco: " + ex.Message);
                    return View(cliente);
                }
            }

            // redireciona após o cadastro do cliente
            return RedirectToAction("Index", "Home");
        }
    }
}