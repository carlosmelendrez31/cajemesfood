using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;


namespace pruebascajemesfood
{

    [TestFixture]
    public class UserRegistroTests
    {
        public IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void SetUp()
        {
            // Inicializa el navegador Chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4218/Mantenedor/Guardar"); // Ajusta la URL
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void RegistroUsuario()
        {
            var Usuarioagg = driver.FindElement(By.Name("Nombre"));
            Usuarioagg.Clear();
            Usuarioagg.SendKeys("");

            // Localiza los campos de entrada y el botón de inicio de sesión
            var Username = driver.FindElement(By.CssSelector("input[name='Nombre']"));
            var password = driver.FindElement(By.CssSelector("input[name='contrasena']"));
            var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

            // Completa los campos con datos de prueba
            Username.SendKeys("Alejandro");
            password.SendKeys("amolavidalulu");

            // Envía el formulario
            loginButton.Click();

            driver.Navigate().GoToUrl("http://localhost:4218/Home/Index"); // redireccion 

            // Verifica el resultado esperado después del envío
            // Por ejemplo, verificar redirección o un mensaje de éxito
            var Completado = wait.Until(driver =>
            {
                var element = driver.FindElement(By.CssSelector(".success-message"));
                return element.Displayed ? element : null;
            });

            Assert.That(Completado.Displayed, Is.True, "El mensaje de éxito no se mostró.");



        }
        /*BASE DE DATOS NO FUNCIONAL
        [TestFixture]
        public class InsertUsuariosTest
        {
            private string connectionString = "Data Source=DESKTOP-70H9HGV;Initial Catalog=cajemesfood;Integrated Security=True;";

            [SetUp]
            public void SetUp()
            {
                // Puedes agregar código para configurar tu entorno antes de cada prueba
            }

            [Test]
            public void InsertarUsuarioTest()
            {
                // Establecer la conexión a la base de datos
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                // Configurar el comando para ejecutar el procedimiento almacenado
                using (var command = new SqlCommand("insertarusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros que requiere el SP
                    command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = "Alejandra";
                    command.Parameters.Add(new SqlParameter("@contrasena", SqlDbType.VarChar)).Value = "amolavidafufu";
                    command.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Int)).Value = 6443019428;

                    // Ejecutar el procedimiento almacenado (puede ser ExecuteNonQuery si no devuelve nada, o ExecuteScalar si devuelve un valor)
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar que se haya insertado un registro
                    Assert.AreEqual(1, rowsAffected, "El procedimiento no insertó el registro correctamente.");
                }

                // Verificar que los datos realmente se insertaron, si es necesario
                // Aquí podrías hacer una consulta SELECT a la base de datos para confirmar la inserción, por ejemplo
                string query = "SELECT * FROM Usuarios WHERE Nombre = 'Alejandro' AND contrasena = 'amolavidafufu' ";
                using (var checkCommand = new SqlCommand(query, connection))
                {
                    int count = (int)checkCommand.ExecuteScalar();
                    Assert.AreEqual(1, count, "El Usuario no fue insertado correctamente.");
                }
            }
        } */
        [TearDown]
        public void Teardown()
        {
            // Cerrar el navegador y liberar recursos
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }

        }

    }

    //pruebas del login
    [TestFixture]
    public class UserLoginTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void SetUp()
        {
            // Inicializa el navegador Chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:4218/"); // pagina de login
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void Loginusuario()
        {

            // Encontrar los campos de usuario y contraseña
            var username = driver.FindElement(By.Id("Nombre"));
            var password = driver.FindElement(By.Id("contrasena"));

            // Ingresar las credenciales
            username.SendKeys("username");
            password.SendKeys("password");

            // Hacer clic en el botón de inicio de sesión
            var loginButton = driver.FindElement(By.Id("btn btn-primary"));
            loginButton.Click();

            var Completado = wait.Until(driver =>
            {
                var element = driver.FindElement(By.CssSelector(".success-message"));
                return element.Displayed ? element : null;
            });

            Assert.That(Completado.Displayed, Is.True, "El mensaje de éxito no se mostró.");



        }
        [TearDown]
        public void Teardown()
        {
            // Cerrar el navegador y liberar recursos
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }

        }

    }
}