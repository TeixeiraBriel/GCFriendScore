using GCFriendsScore.Entidades;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCFriendsScore
{
    public class SeleniumApps
    {
        bool primeira = true;

        private readonly string file = "Itens\\DadosUsuarios.csv";
        bool driveOn = false;
        IWebDriver driver;

        public void verificarDrive()
        {
            if (!driveOn)
            {
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                driveOn = true;
            }
            else
            {
                driver.Quit();
                driveOn = false;
            }
        }

        public void inserirlinha(List<Amigos> listaBase)
        {
            //Amigos novo, DateTime Data

            string Data = DateTime.Now.ToString("dd/MM/yyyy");
            foreach (var Amigo in listaBase)
            {
                if (primeira)
                {
                    Logar(Amigo.Id);
                    primeira = false;
                }
                else
                {
                    driver.Navigate().GoToUrl("https://gamersclub.com.br/jogador/" + Amigo.Id);
                }



                Thread.Sleep(5000);
                Thread.Sleep(5000);

                IWebElement btnHistorico = driver.FindElement(By.XPath("//div[3]/div/button[2]"));
                btnHistorico.SendKeys("");
                Thread.Sleep(1000);
                btnHistorico.SendKeys("");
                btnHistorico.Click();
                Thread.Sleep(1000);


                Usuario modelo = new Usuario();
                modelo.Id = Amigo.Id;
                modelo.Nome = Amigo.Nome; ;
                modelo.KDA = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[1]/div/div/div[2]")).Text;
                modelo.ADR = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[2]/div/div/div[2]")).Text;
                modelo.Matou = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[3]/div/div/div[2]")).Text;
                modelo.Morreu = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[4]/div/div/div[2]")).Text;
                modelo.KAST = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[5]/div/div/div[2]")).Text;
                modelo.MultiKills = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[6]/div/div/div[2]")).Text;
                modelo.FirstKills = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[7]/div/div/div[2]")).Text;
                modelo.Clutches = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[8]/div/div/div[2]")).Text;
                modelo.Hs = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[9]/div/div/div[2]")).Text;
                modelo.Precisao = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[10]/div/div/div[2]")).Text;
                modelo.BombasPlan = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[11]/div/div/div[2]")).Text;
                modelo.BombasDef = driver.FindElement(By.XPath("//*[@id='GamersClubStatsBox']/div/div/div[2]/div[4]/div[12]/div/div/div[2]")).Text;
                modelo.UltAtualizacao = Data;

                var csv = new StringBuilder();
                var newline = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", modelo.Id, modelo.Nome, modelo.KDA, modelo.ADR, modelo.Matou, modelo.Morreu, modelo.KAST, modelo.MultiKills, modelo.FirstKills, modelo.Clutches, modelo.Hs, modelo.Precisao, modelo.BombasPlan, modelo.BombasDef, modelo.UltAtualizacao);
                csv.AppendLine(newline);

                File.AppendAllText(file, csv.ToString());
            }
            primeira = true;
            verificarDrive();
        }

        public void Logar(string Id)
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driveOn = true;

            driver.Navigate().GoToUrl("https://gamersclub.com.br/jogador/" + Id);

            driver.Manage().Window.Maximize();
            
            IWebElement btnEntrar = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/section/form/div[4]/a"));

            btnEntrar.Click();

            Thread.Sleep(5000);
            Thread.Sleep(5000);

            IWebElement loginLabel = driver.FindElement(By.XPath("//*[@id='steamAccountName']"));
            IWebElement passLabel = driver.FindElement(By.XPath("//*[@id='steamPassword']"));
            IWebElement btnLogin = driver.FindElement(By.XPath("//*[@id='imageLogin']"));
            loginLabel.SendKeys("Projetosgt_Testes");
            passLabel.SendKeys("truc0123");
            btnLogin.Click();

            Thread.Sleep(5000);

        }

        //public bool ResetarCsv()
        //{
        //    File.Create(file);

        //    return true;
        //}

        //public void ResetarCsvPT2()
        //{
        //    var csv = new StringBuilder();
        //    var newline = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", "Id", "Nome", "KDA", "ADR", "Matou", "Morreu", "KAST", "MultiKills", "FirstKills", "Clutches", "Hs", "Precisao", "BombasPlan", "BombasDef", "UltAtualizacao");
        //    csv.AppendLine(newline);

        //    File.AppendAllText(file, csv.ToString());
        //}
    }
}
