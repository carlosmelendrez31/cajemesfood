using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace pruebascajemesfood
{
<<<<<<< Updated upstream
    [TestFixture]
    public class AdminLoginTest
=======
    internal class Admin
>>>>>>> Stashed changes
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
            driver.Navigate().GoToUrl("http://localhost:4218/Admin/Login"); // Cambia esta URL según tu configuración
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        [Test]
        public void AdminLogin()
        {
            // Localiza los campos de entrada y el botón de inicio de sesión
            var nombreadmin = driver.FindElement(By.CssSelector("input[name='Nombre']"));
            var contraadmin = driver.FindElement(By.CssSelector("input[name='contrasena']"));
            var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));

            // Completa los campos con datos válidos
            nombreadmin.SendKeys("Alexadmin");
            contraadmin.SendKeys("alexadmin");

            // Haz clic en el botón de inicio de sesión
            loginButton.Click();

            // Verifica el resultado esperado (por ejemplo, redirección o mensaje de éxito)
            var Completado = wait.Until(driver =>
            {
                var element = driver.FindElement(By.CssSelector(".success-message"));
                return element.Displayed ? element : null;
            });
            Assert.IsTrue(Completado.Displayed, "El mensaje de éxito no se mostró.");
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
    }

}