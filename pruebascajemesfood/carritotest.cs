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
    public void Setup()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    public void AgregarProductoAlCarrito_DeberiaMostrarProductoEnCarrito()
    {
        // Navegar a la p�gina principal
        driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");

        // Buscar el formulario de un producto espec�fico y completarlo
        var productoFormulario = wait.Until(d => d.FindElement(By.CssSelector("div.card-body form")));
        var cantidadInput = productoFormulario.FindElement(By.Name("cantidad"));
        cantidadInput.Clear();
        cantidadInput.SendKeys("2");

        // Hacer clic en "A�adir al Carrito"
        var addToCartButton = productoFormulario.FindElement(By.CssSelector("button[type='submit']"));
        addToCartButton.Click();

        // Esperar a que el elemento del carrito se actualice
        var itemCantidad = wait.Until(d =>
        {
            try
            {
                return d.FindElement(By.CssSelector("p.card-text.Cantidad"));
            }
            catch (NoSuchElementException)
            {
                return null; // Seguir esperando
            }
        });

        // Verificar que el elemento no sea nulo y que contiene la cantidad esperada
        Assert.IsNotNull(itemCantidad, "El producto no fue a�adido al carrito.");
        Assert.IsTrue(itemCantidad.Text.Contains("Cantidad: 2"), "La cantidad en el carrito no coincide con la cantidad seleccionada.");
    }

    [Test]
    public void AgregarProductoYComprarTodo_DeberiaRedirigirAGracias()
    {
        // Navegar a la p�gina principal
        driver.Navigate().GoToUrl("http://localhost:5034/carrito/index");

        // Buscar el formulario de un producto espec�fico y completarlo
        var productoFormulario = wait.Until(d => d.FindElement(By.CssSelector("div.card-body form")));
        var cantidadInput = productoFormulario.FindElement(By.Name("cantidad"));
        cantidadInput.Clear();
        cantidadInput.SendKeys("2");

        // Hacer clic en "A�adir al Carrito"
        var addToCartButton = productoFormulario.FindElement(By.CssSelector("button[type='submit']"));
        addToCartButton.Click();

        // Esperar a que el formulario de "Comprar Todo" se muestre
        var comprarTodoButton = wait.Until(d =>
        {
            try
            {
                return d.FindElement(By.CssSelector("body > div > main > form > button"));
            }
            catch (NoSuchElementException)
            {
                return null; // Seguir esperando si no se encuentra
            }
        });

        // Verificar que el bot�n "Comprar Todo" est� presente
        Assert.IsNotNull(comprarTodoButton, "El bot�n 'Comprar Todo' no se encontr�.");

        // Desplazar hacia el bot�n "Comprar Todo" para asegurarse de que est� visible
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", comprarTodoButton);

        // Esperar un poco m�s para que el bot�n sea completamente accesible
        wait.Until(d => comprarTodoButton.Displayed && comprarTodoButton.Enabled);

        // Hacer clic usando JavaScript para evitar problemas de intercepci�n
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", comprarTodoButton);

        // Esperar a que la p�gina de redirecci�n a "Gracias" se cargue
        wait.Until(d => d.Url.Contains("Gracias"));

        // Verificar que la URL contiene "Gracias" como esperado
        Assert.IsTrue(driver.Url.Contains("Gracias"), "La redirecci�n a la p�gina de Gracias fall�.");
    }


}

