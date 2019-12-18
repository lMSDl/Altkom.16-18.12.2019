using Altkom.Siemens.CSharp.DAL.Services;
using Altkom.Siemens.CSharp.IServices;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Altkom.Siemens.CSharp.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ICrudAsync<Person> Service { get; } = new PersonServiceAsync();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ICollection<Person> People { get; set; }
        public Person SelectedPerson { get; set; }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            People = (await Service.ReadAsync()).ToList();
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(People)));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PersonWindow(SelectedPerson);
            dialog.ShowDialog();
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson == null)
                return;
            await Service.DeleteAsync(SelectedPerson.GetType(), SelectedPerson.GetId());
            ButtonRefresh_Click(this, new RoutedEventArgs());
        }
    }
}
