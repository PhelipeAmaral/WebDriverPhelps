using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverPhelps.Data;
using WebDriverPhelps.Models;

namespace WebDriverPhelps.Repository
{
    public class SeleniumWeb : ISeleniumWeb
    {
        public IWebDriver? driver;
        private readonly BancoContext _bancoContext;

        public SeleniumWeb(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public void ExtrairRelatorioIndividual(int arId, DateTime dataini, DateTime datafim)
        {
            try
            {
                ArModel arModel = ListarPorId(arId);
                string link = arModel.LinkAR;

                driver = new ChromeDriver();

                driver.Navigate().GoToUrl($"{link}");
                driver.Manage().Window.Maximize();

                driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]/li[2]/a")).Click();
                driver.FindElement(By.Id("precert")).Click();
                driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]/li[5]/a")).Click();
                driver.FindElement(By.XPath("//*[@id=\"linkBox\"]/ul/li[2]/a/span")).Click();
                Thread.Sleep(1500);
                driver.FindElement(By.Id("datafim")).Clear();
                driver.FindElement(By.Id("datafim")).SendKeys($"{datafim.ToString("dd/MM/yyyy")}");
                Thread.Sleep(1500);
                driver.FindElement(By.Id("gerarcsv")).Click();
                Thread.Sleep(1500);
                driver.FindElement(By.Id("dataini")).Clear();
                driver.FindElement(By.Id("dataini")).SendKeys($"{dataini.ToString("dd/MM/yyyy")}");
                Thread.Sleep(1500);
                driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[1]/p[1]/strong")).Click();
                driver.FindElement(By.Id("submit_label")).Click();
                Thread.Sleep(8000);



                driver.Quit();
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao extrair a planilha");
            }
        }

        public ArModel ListarPorId(int id)
        {
            var ar = _bancoContext.AR.SingleOrDefault(x => x.Id == id);
            if (ar == null)
                throw new Exception("AR " + id + " não encontrada.");
            
            return ar;
        }

        public void RelatorioCompletoPorAC(int arId, DateTime dataini, DateTime datafim)
        {
            try
            {
                driver = new ChromeDriver();

                foreach (var ar in BuscarPorAC(arId))
                {
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "t");
                    driver.Navigate().GoToUrl($"{ar.LinkAR}");
                    driver.Manage().Window.Maximize();

                    driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]/li[2]/a")).Click();
                    driver.FindElement(By.Id("precert")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]/li[5]/a")).Click();
                    driver.FindElement(By.XPath("//*[@id=\"linkBox\"]/ul/li[2]/a/span")).Click();
                    Thread.Sleep(1500);
                    driver.FindElement(By.Id("datafim")).Clear();
                    driver.FindElement(By.Id("datafim")).SendKeys($"{datafim.ToString("dd/MM/yyyy")}");
                    Thread.Sleep(1500);
                    driver.FindElement(By.Id("gerarcsv")).Click();
                    Thread.Sleep(1500);
                    driver.FindElement(By.Id("dataini")).Clear();
                    driver.FindElement(By.Id("dataini")).SendKeys($"{dataini.ToString("dd/MM/yyyy")}");
                    Thread.Sleep(1500);
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[1]/p[1]/strong")).Click();
                    driver.FindElement(By.Id("submit_label")).Click();
                    Thread.Sleep(10000);
                }

                driver.Quit();
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao extrair as planilhas");
            }


        }

        public IQueryable<ArModel> BuscarPorAC(int ac_id)
            => _bancoContext.AR.Where(x => x.Ac_id == ac_id).OrderBy(x => x.Nome);

        public IQueryable<ArModel> BuscarTodos()
            => _bancoContext.AR.OrderBy(x => x.Nome);
    }
}
