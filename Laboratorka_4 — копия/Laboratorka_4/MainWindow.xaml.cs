using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using static Laboratorka_4.MainWindow;

namespace Laboratorka_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int a = 0;
        static Marsh[] marshArray = new Marsh[8];

        

        public MainWindow()
        {
            
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_start.Text != null && tb_end.Text != null && Convert.ToDouble(tb_num.Text) >= 0)
            {
                marshArray[a] = new Marsh(tb_start.Text.ToString(), tb_end.Text.ToString(), Convert.ToDouble(tb_num.Text));
                a++;
                index.Text = $"Massive index:{a}";
            }

            else if (tb_start.Text == "" || tb_end.Text == "" || Convert.ToDouble(tb_num.Text) < 0) {


                tb_start.Text = "";
                tb_end.Text = null;
                tb_num.Text = null;

                Button btn = (Button)sender;

                // Изменение цвета кнопки на красный
                btn.Background = Brushes.Red;
                index.Text = $"Massive index:{a}";

                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb_start.Text = null;
            tb_end.Text = null;
            tb_num.Text = null;

            
            index.Text = $"Massive index:{a}";
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int aa = 0;
            for (int i = 0; i < a; i++)
            { if ((tb_search.Text == marshArray[i].Startpoint || tb_search.Text == marshArray[i].Endpoint) && aa==0)
                {
                    tb_start_1.Text = marshArray[i].Startpoint.ToString();
                    tb_end_1.Text = marshArray[i].Endpoint.ToString();
                    tb_num_1.Text = marshArray[i].Marsh_num.ToString();
                    aa = 1;
                    


                }
             
                }
            if (aa == 0) MessageBox.Show("Нет совпадений");




        }


        Clone cloned = new Clone(marshArray);

        // Создаем экземпляр класса MarshComparer
        MarshComparer comparer = new MarshComparer();

        // Сортируем массив marshArray по полю startStop
        //Array.Sort(cloned.arr, comparer);
        public interface Icomparable
        {
             int Compare(Marsh x, Marsh y);
        }
        public interface Iclonable
        { Marsh [] Clonee(Marsh [] cloned);
        }

        public class Clone : Iclonable
        {

            private Marsh[] arr;

            public Marsh[] Clonee(Marsh[] ar ) { return ar; } 
            public Marsh[] Arr {get{return arr;} set {arr = value;}  }

            public Clone(Marsh[] a) { Arr = a; }
        }

    }

    class MarshComparer:Icomparable
    {
        public int Compare(Marsh x, Marsh y)
        {
            return string.Compare(x.Startpoint, y.Startpoint);
        }
    }

   
  


    public class Marsh
    {

        private string startpoint;
        private string endpoint;
        private double marsh_num;


        
        


        public string Startpoint {
        
        get { return startpoint; } set { if (value != null) startpoint = value; }
        }

        public string Endpoint
        {

            get { return endpoint; }
            set { if (value != null) endpoint = value; }
        }

        public double Marsh_num
        {
            get {return marsh_num; }
            set {if(value != null) marsh_num=value; } 

        }

        public Marsh(string start, string end, double num) 
        { 
            startpoint = start;
            endpoint = end; 
            marsh_num = num;
        
        
        }
    }

}
