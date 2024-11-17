using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography.X509Certificates;

[TestFixture]
public class CarritoTests
{
    private IWebDriver driver;
    private WebDriverWait wait;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); // Aumenta el tiempo de espera
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void AñadirAlCarrito_DeberiaIncrementarCantidad()
    {
        driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");

        var cantidadInput = wait.Until(d => d.FindElement(By.Name("cantidad")));
        cantidadInput.Clear();
        cantidadInput.SendKeys("1");

        var addToCartButton = driver.FindElement(By.CssSelector("button[type='submit']"));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCartButton);
        addToCartButton.Click();
        Thread.Sleep(5000);
        // Espera a que el contenedor del carrito se renderice después de agregar el producto
        var carritoItems = wait.Until(driver => driver.FindElements(By.XPath("//div[contains(@class, 'card-body')]")));

        bool productoEncontrado = false;
        foreach (var item in carritoItems)
        {
            try
            {
                var cantidadEnCarrito = item.FindElement(By.XPath(".//p[contains(text(), 'cantidad:')]")).Text;
                if (cantidadEnCarrito.Contains("cantidad: 1"))
                {
                    productoEncontrado = true;
                    break;
                    Assert.That(productoEncontrado, Is.True, "El producto fue añadido");
                }
            }
            catch (NoSuchElementException)
            {
                // Ignorar si no se encuentra el elemento en este item
            }
        }
        
        

       
    }
    [SetUp]
    public void SetUp2()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://localhost:5034/carrito/index"); // Reemplaza con la URL de tu aplicación
    }

    [TearDown]
    public void TearDown2()
    {
        driver.Quit();
    }

    [Test]
    public void AñadirDosProductosDiferentesAlCarrito()
    {
        // Añadir primer producto
        var primerProducto = wait.Until(d => d.FindElement(By.CssSelector("body > div > main > div > div > div:nth-child(2) > div > div > form > input[type=hidden]:nth-child(1)")));
        primerProducto.FindElement(By.Name("cantidad")).SendKeys("1");
        primerProducto.FindElement(By.Name("añadir-al-carrito")).Click();

        // Añadir segundo producto
        var segundoProducto = wait.Until(d => d.FindElement(By.CssSelector("body > div > main > div > div > div:nth-child(3) > div > div > form > input[type=hidden]:nth-child(1)")));
        segundoProducto.FindElement(By.Name("cantidad")).SendKeys("1");
        segundoProducto.FindElement(By.Name("añadir-al-carrito")).Click();

        // Verificar que ambos productos están en el carrito
        var carrito = wait.Until(d => d.FindElement(By.Id("carrito")));
        var itemsCarrito = carrito.FindElements(By.ClassName("item-carrito"));

        Assert.AreEqual(2, itemsCarrito.Count);
        Assert.IsTrue(itemsCarrito.Any(item => item.Text.Contains("Nombre del Producto 1"))); // Reemplaza con el nombre del producto
        Assert.IsTrue(itemsCarrito.Any(item => item.Text.Contains("Nombre del Producto 2"))); // Reemplaza con el nombre del producto
    }
}
