using Microsoft.AspNetCore.Mvc;
using WebCrud.Models;
using MySql.Data.MySqlClient;

namespace WebCrud.Controllers
{ 

    public class MaterialController : Controller
    {
        private readonly IConfiguration _configuration;

        public MaterialController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CadastrarMat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarMat(Material material)
        {
            if (!ModelState.IsValid)
            {
                return View(material);
            }

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO tbMaterial (nome_material, qtd_estoque, validade, fkFornecedorid) " +
                                 "VALUES (@NomeMat, @QuantMat, @ValiMat, @Fkfornecedorid)";

                    using MySqlCommand command = new MySqlCommand(sql, connection);
                    {
                        command.Parameters.AddWithValue("@NomeMat", material.NomeMat);
                        command.Parameters.AddWithValue("@QuantMat", material.QuantMat);
                        command.Parameters.AddWithValue("@ValiMat", material.ValiMat);
                        command.Parameters.AddWithValue("@Fkfornecedorid", material.Fkfornecedorid);

                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao registrar o material no banco de dados: " + ex.Message);
                    return View(material);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
