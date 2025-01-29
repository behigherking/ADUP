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

namespace ADDB
{
    /// <summary>
    /// Логика взаимодействия для EditAdPage.xaml
    /// </summary>
    public partial class EditAdPage : Page
    {
        private Advertisement _currentAd;
        private Entities _context = new Entities();

        public EditAdPage(Advertisement selectedAd)
        {
            InitializeComponent();
            _currentAd = selectedAd ?? new Advertisement();
            DataContext = _currentAd;
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            CityComboBox.ItemsSource = _context.City.ToList();
            CityComboBox.SelectedValue = _currentAd.CityID;

            CategoryComboBox.ItemsSource = _context.AdCategory.ToList();
            CategoryComboBox.SelectedValue = _currentAd.CategoryID;

            StatusComboBox.ItemsSource = _context.StatusType.ToList();
            StatusComboBox.SelectedValue = _currentAd.TypeID;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentAd.AdID == 0)
                    _context.Advertisement.Add(_currentAd);

                _context.SaveChanges();
                MessageBox.Show("Объявление сохранено успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

