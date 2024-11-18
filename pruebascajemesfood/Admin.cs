using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data.SqlClient;
using System.Data;

namespace pruebascajemesfood
{
    [TestFixture]
    public class AdminTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void SetUp()
        {
            // Inicializa el navegador Chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Navega a la página del formulario de inicio de sesión
            driver.Navigate().GoToUrl("http://localhost:5034/Admin/Guardaradmin"); // Cambia esta URL según tu configuración
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void AdminLogin()
        {
            // Localiza los campos de entrada y el botón de inicio de sesión
            var nombreadmin = driver.FindElement(By.CssSelector("input[name='Nombre']"));
            var contraadmin = driver.FindElement(By.CssSelector("input[name='contrasena']"));
            

            // Completa los campos con datos válidos
            nombreadmin.SendKeys("Carlos");
            contraadmin.SendKeys("123");

            // Haz clic en el botón de inicio de sesión


            // Verifica el resultado esperado (por ejemplo, redirección o mensaje de éxito)
            var loginButton = driver.FindElement(By.CssSelector("body > div > main > form > button"));
            loginButton.Click();

            var Completado = wait.Until(driver =>
            {
                // Verifica si la URL actual coincide con la URL esperada tras la redirección.
                var currentUrl = driver.Url;
                return currentUrl.Contains("http://localhost:5034/Mantenedor/Index") ? currentUrl : null;
            });

            Assert.That(Completado, Is.EqualTo("http://localhost:5034/Mantenedor/Index"), "No se redirigió a la página esperada.");
        }
        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador después de cada prueba
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
        public void Setup()
        {
            // Configura el navegador (Chrome en este caso)
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5034/Admin/Guardaradmin"); // URL de la página del formulario
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void LlenarFormulario_ConDatosValidos_DebeEnviarFormulario()
        {
            // Localiza el campo "Nombre" y escribe un valor
            var nombreInput = driver.FindElement(By.Name("Nombre")); // Usa el atributo "asp-for" para localizar elementos
            nombreInput.Clear();
            nombreInput.SendKeys("Alex");

            // Localiza el campo "Contraseña" y escribe un valor
            var contrasenaInput = driver.FindElement(By.Name("Apellido"));
            contrasenaInput.Clear();
            contrasenaInput.SendKeys("Cantu");

            // Localiza el campo "Teléfono" y escribe un valor
            var telefonoInput = driver.FindElement(By.Name("contrasena"));
            telefonoInput.Clear();
            telefonoInput.SendKeys("123");

            // Localiza y envía el formulario (haz clic en el botón "Guardar")
            var guardarButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            guardarButton.Click();

            var Completado = wait.Until(driver =>
            {
                // Verifica si la URL actual coincide con la URL esperada tras la redirección.
                var currentUrl = driver.Url;
                return currentUrl.Contains("http://localhost:5034/Admin/Listaradmin") ? currentUrl : null;
            });

            Assert.That(Completado, Is.EqualTo("http://localhost:5034/Admin/Listaradmin"), "No se redirigió a la página esperada.");
        }

        [TearDown]
        public void TearDown2()
        {
            // Cierra el navegador al finalizar la prueba
            driver.Quit();
        }







    }
    [TestFixture]
    public class ListarUsuariosTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            // Inicializa el navegador
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void Test_VerificarVistaListarUsuarios()
        {
            // Navega a la URL proporcionada
            _driver.Navigate().GoToUrl("http://localhost:5034/Mantenedor/Listar");

            // Espera que la tabla de usuarios (o cualquier elemento representativo) sea visible
            var tablaUsuarios = _wait.Until(driver => driver.FindElement(By.CssSelector("body > div > main > div > div.card-body > table"))); // Ajusta el ID o selector según tu implementación

            // Verifica que la tabla de usuarios esté visible
            Assert.IsTrue(tablaUsuarios.Displayed, "La tabla de usuarios no está visible en la vista de listar usuarios.");
        }

        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador después de la prueba
            _driver.Quit();
            _driver.Dispose();
        }
    }
    [TestFixture]
    public class ListarcomprasTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void SetUp2()
        {
            // Inicializa el navegador
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void Test_Verificarcompras()
        {
            // Navega a la URL proporcionada
            _driver.Navigate().GoToUrl("http://localhost:5034/carrito/Listarcompra");

            // Espera que la tabla de usuarios (o cualquier elemento representativo) sea visible
            var tablaUsuarios = _wait.Until(driver => driver.FindElement(By.CssSelector("body > div > main > div > div.card-body > table"))); // Ajusta el ID o selector según tu implementación

            // Verifica que la tabla de usuarios esté visible
            Assert.IsTrue(tablaUsuarios.Displayed, "La tabla de usuarios no está visible en la vista de listar usuarios.");
        }

        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador después de la prueba
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
