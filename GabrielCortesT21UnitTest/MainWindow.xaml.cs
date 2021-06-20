using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geometria;

namespace GabrielCortesT21UnitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {//lo hago así para aprender más

            TabItem tbFigura;
            Figura figura;
            StackPanel stkParametros;
            StackPanel stkParametro;
            TextBox txtParametro;
            Label lblParametro;
            Button btnCalcular;

            InitializeComponent();
            //añado las figuras
            for (int i = Figura.PRIMERO; i <= Figura.ULTIMO; i++)
            {
                figura = new Figura(i);
                tbFigura = new TabItem();
                tbFigura.Header = figura.Nom;
                tbFigura.Tag = figura;
                stkParametros = new StackPanel();
                tbFigura.Content = stkParametros;
                foreach (string parametro in figura.Args)
                {
                    //lbl:txtBox
                    stkParametro = new StackPanel() { Tag = true , Orientation = Orientation.Horizontal };

                    lblParametro = new Label() { Content = $"{parametro}:", Width = 100 };
                    txtParametro = new TextBox() { Width = 50 };
                    txtParametro.PreviewTextInput += TextBox_PreviewTextInput;

                    stkParametro.Children.Add(lblParametro);
                    stkParametro.Children.Add(txtParametro);

                    stkParametros.Children.Add(stkParametro);

                }
                stkParametro = new StackPanel() { Tag = false };

                btnCalcular = new Button() { Content = "Calcular Area" };

                btnCalcular.Click += Calcular;
                lblParametro = new Label();
                stkParametro.Children.Add(btnCalcular);
                stkParametro.Children.Add(lblParametro);

                stkParametros.Children.Add(stkParametro);

                tbMain.Items.Add(tbFigura);
            }
        }



        private void Calcular(object sender, RoutedEventArgs e)
        {
            StackPanel stkParam;
            StackPanel stkButton = (sender as Button).Parent as StackPanel;
            StackPanel stkParentParentBtn = stkButton.Parent as StackPanel;
            Figura figura = (stkParentParentBtn.Parent as TabItem).Tag as Figura;
            List<int> args = new List<int>();

            foreach (UIElement item in stkParentParentBtn.Children)
            {
                stkParam = item as StackPanel;
                if ((bool)stkParam.Tag)
                {
                    args.Add(int.Parse((stkParam.Children[1] as TextBox).Text));
                }
            }
            (stkButton.Children[1] as Label).Content = $"Result: {figura.Area(args)}";

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = System.Text.RegularExpressions.Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
