using GCFriendsScore.Entidades;
using GCFriendsScore.Fixtures;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace GCFriendsScore
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        CSV_AmigosProvider CsvAmigosExec = new CSV_AmigosProvider();
        CSV_UsuariosProvider CsvUserExec = new CSV_UsuariosProvider();
        SeleniumApps CsvSelExec = new SeleniumApps();
        string hoje = DateTime.Now.ToString("dd/MM/yyyy");
        bool csvBranco = false;

        public MainWindow()
        {
            InitializeComponent();
            atualizarView();
            if (true)
            {
                
            }
        }

        public void AtualizarTela()
        {
            List<Amigos> ListaAmigos = CsvAmigosExec.Lista;
            List<Usuario> ListaUsuarios =  CsvUserExec.Lista;

            foreach (var User in ListaUsuarios)
            {

                PainelUsuarios.Children.Add(PreencherLinhaUsuario(User.Id, User.Nome, User.KDA, User.ADR,User.Matou,User.Morreu, User.KAST, User.MultiKills, User.FirstKills, User.Clutches, User.Hs, User.Precisao, User.BombasPlan, User.BombasDef));
            }
            foreach (var User in ListaAmigos)
            {
                PainelAmigos.Children.Add(PreencherLinhaAmigos(User.Id, User.Nome));
            }

        }

        public StackPanel PreencherLinhaUsuario( string IdPar, string NomePar, string KdaPar, string AdrPar, string MatouPar, string MorreuPar, string KastPar, string MkPar, string FkPar, string ClutchPar, string HsPar, string PrecisaoPar, string BombaPlanPar, string BombaDefPar)
        {
            //Tentar!!
            //Se ja existe o registro em vez de criar um novo stackpanel, editar o atual?
            //Ou...Editar o csv...

            if (!CsvUserExec.Lista.Exists(xy => xy.Id == IdPar))
            {
            }          

            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal,  Name = "Amigo" + IdPar.ToString() };

            Label Nome = new Label { Content = NomePar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Kda = new Label { Content = KdaPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Adr = new Label { Content = AdrPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Matou = new Label { Content = MatouPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Morreu = new Label { Content = MorreuPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Kast = new Label { Content = KastPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label MultiKills = new Label { Content = MkPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label FirstKills = new Label { Content = FkPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Clutches = new Label { Content = ClutchPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Hs = new Label { Content = HsPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Precisao = new Label { Content = PrecisaoPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label BombasPlan = new Label { Content = BombaPlanPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label BombasDef = new Label { Content = BombaDefPar, Width = 80, HorizontalContentAlignment = HorizontalAlignment.Center };

            stackPanel.Children.Add(Nome);
            stackPanel.Children.Add(Kda);
            stackPanel.Children.Add(Adr);
            stackPanel.Children.Add(Matou);
            stackPanel.Children.Add(Morreu);
            stackPanel.Children.Add(Kast);
            stackPanel.Children.Add(MultiKills);
            stackPanel.Children.Add(FirstKills);
            stackPanel.Children.Add(Clutches);
            stackPanel.Children.Add(Hs);
            stackPanel.Children.Add(Precisao);
            stackPanel.Children.Add(BombasPlan);
            stackPanel.Children.Add(BombasDef);

            return stackPanel;
        }

        public StackPanel PreencherLinhaAmigos(string IdPar, string NomePar)
        {
            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Name = "Amigo" + IdPar.ToString() };

            Label Id = new Label { Content = IdPar, Width = 100, HorizontalContentAlignment = HorizontalAlignment.Center };
            Label Nome = new Label { Content = NomePar, Width = 100, HorizontalContentAlignment = HorizontalAlignment.Center };
            

            stackPanel.Children.Add(Id);
            stackPanel.Children.Add(Nome);

            return stackPanel;
        }
        public void Limpar()
        {
            PainelAmigos.Children.Clear();
            PainelUsuarios.Children.Clear();
        }
        public void atualizarView()
        {
            Limpar();
            PainelUsuarios.Children.Clear();
            CsvAmigosExec.CarregaDados();
            CsvUserExec.CarregaDados();
            AtualizarTela();
        }
            


        //Botões//

        private void btnNovo(object sender, RoutedEventArgs e)
        {
        }
        private void btnTeste(object sender, RoutedEventArgs e)
        {
        }
        private void btnAtualizar(object sender, RoutedEventArgs e)  //Chama Metodo que atualiza
        {
            atualizarView();
        }
        private void btnAtualizarDados(object sender, RoutedEventArgs e)  //Chama Metodo que atualiza
        {
            System.Diagnostics.Process.Start("Itens\\_Apaga.exe");
            System.Diagnostics.Process.Start("Itens\\_Escreve.exe");

            List<Amigos> listaBase = CsvAmigosExec.Lista;
            List<Usuario> listaAtual = CsvUserExec.Lista;
            CsvSelExec.inserirlinha(listaBase);
        }
        private void btnNovoAmigo(object sender, RoutedEventArgs e)  //chama metodo que atualiza
        {
            Amigos novo = new Amigos();
            List<Amigos> listaBase = new List<Amigos>();

            novo.Id = inputId.Text;
            novo.Nome = inputNome.Text;
            listaBase.Add(novo);            

            CsvAmigosExec.inserirlinha(novo.Id, novo.Nome);
            CsvSelExec.inserirlinha(listaBase);
        }       
    }
}
