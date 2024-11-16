using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace pruebascajemesfood
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Inicializa el navegador
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void AñadirAlCarrito_DeberiaIncrementarCantidad()
        {
            // Navega a la página de productos
            driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");

            // Encuentra el campo de cantidad e ingresa un valor
            var cantidadInput = driver.FindElement(By.Name("cantidad"));
            cantidadInput.Clear();
            cantidadInput.SendKeys("1");

            // Encuentra y llena el campo hidden del producto
            var productIdInput = driver.FindElement(By.Name("productId"));
            Assert.That(productIdInput.GetAttribute("value"), Is.EqualTo("15"), "El ID del producto no es correcto.");

            // Haz clic en el botón "Añadir al Carrito"
            var addToCartButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            addToCartButton.Click();

            // Verifica que se redirige al índice o actualiza el carrito
            driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");

            // Verifica que el producto fue añadido al carrito
            var productoEnCarrito = driver.FindElement(By.CssSelector("tr[data-product-id='1']"));
            Assert.That(productoEnCarrito, Is.Not.Null, "El producto no fue añadido al carrito.");

            // Verifica la cantidad del producto en el carrito
            var cantidad = productoEnCarrito.FindElement(By.CssSelector(".cantidad"));
            Assert.That(cantidad.Text, Is.EqualTo("1"), "La cantidad del producto no es correcta.");

            // Simula agregar nuevamente el producto
            driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");
            addToCartButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            addToCartButton.Click();

            // Verifica que la cantidad ha aumentado
            driver.Navigate().Refresh();
            cantidad = productoEnCarrito.FindElement(By.CssSelector(".cantidad"));
            Assert.That(cantidad.Text, Is.EqualTo("2"), "La cantidad del producto no se actualizó correctamente.");
        }

        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador
            driver.Quit();
        }

    }
}