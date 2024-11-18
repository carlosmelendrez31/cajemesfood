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
        private IWebDriver _driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            // Configura el navegador (Chrome en este caso)
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://localhost:5034/Mantenedor/Guardar"); // URL de la página del formulario
            _driver.Manage().Window.Maximize();

        }

        [Test]
        public void LlenarFormulario_ConDatosValidos_DebeEnviarFormulario()
        {
            // Localiza el campo "Nombre" y escribe un valor
            var nombreInput = _driver.FindElement(By.Name("Nombre")); // Usa el atributo "asp-for" para localizar elementos
            nombreInput.Clear();
            nombreInput.SendKeys("Prueba Selenium");

            // Localiza el campo "Contraseña" y escribe un valor
            var contrasenaInput = _driver.FindElement(By.Name("contrasena"));
            contrasenaInput.Clear();
            contrasenaInput.SendKeys("Prueba1234");

            // Localiza el campo "Teléfono" y escribe un valor
            var telefonoInput = _driver.FindElement(By.Name("Telefono"));
            telefonoInput.Clear();
            telefonoInput.SendKeys("1234567890");

            // Localiza y envía el formulario (haz clic en el botón "Guardar")
            var guardarButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            guardarButton.Click();

            // Agregar aserción para verificar el resultado esperado (por ejemplo, redirección a otra página o mensaje de éxito)
            Assert.IsTrue(_driver.Url.Contains("Index"), "La redirección a la página de listado falló.");
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador al finalizar la prueba
            _driver.Quit();
        }
    }
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
            driver.Navigate().GoToUrl("http://localhost:5034/Auth/Login"); // pagina de login
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void Loginusuario()
        {

            // Encontrar los campos de usuario y contraseña
            var username = driver.FindElement(By.Id("Nombre"));
            var password = driver.FindElement(By.Id("contrasena"));

            // Ingresar las credenciales
            username.SendKeys("Pacheco");
            password.SendKeys("123");

            // Hacer clic en el botón de inicio de sesión
            var loginButton = driver.FindElement(By.CssSelector("body > div > main > form > button"));
            loginButton.Click();

            var Completado = wait.Until(driver =>
            {
                // Verifica si la URL actual coincide con la URL esperada tras la redirección.
                var currentUrl = driver.Url;
                return currentUrl.Contains("http://localhost:5034/Home/Index") ? currentUrl : null;
            });

            Assert.That(Completado, Is.EqualTo("http://localhost:5034/Home/Index"), "No se redirigió a la página esperada.");



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
