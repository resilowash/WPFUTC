using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace WPFUTC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timeTimer;
        private String now;
        private bool is24HrTime; 

        public MainWindow()
        {
            InitializeComponent();
            now = DateTime.UtcNow.ToString("hh:mm:ss t");
            this.timebox.Text = now;
            this.is24HrTime = false; 
            
            timeTimer = new DispatcherTimer();
            timeTimer.Tick += new EventHandler(timer_Tick);
            timeTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timeTimer.Start();

            this.radio24HrTime.IsChecked = this.is24HrTime;
        }

        private void timer_Tick(Object source, EventArgs e)
        {
            if(is24HrTime)
                now = DateTime.UtcNow.ToString("HH:mm:ss ");
            else
                now = DateTime.UtcNow.ToString("hh:mm:ss tt");

            timebox.Text = now;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.is24HrTime = !is24HrTime;
            this.radio24HrTime.IsChecked = this.is24HrTime;
        }
    }
}
