using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ADDB
{
    public partial class AD : Page
    {
        public AD()
        {
            InitializeComponent();
            CategoryComboBox.ItemsSource = Entities.GetContext().AdCategory.ToList();
            CityFilter.ItemsSource = Entities.GetContext().City.ToList();
            StatusFilter.ItemsSource = Entities.GetContext().AdType.ToList();
            UpdateAds(); 
        }

        private void UpdateAds()
        {
            var currentAds = Entities.GetContext().Advertisement.ToList();

            // Фильтр по ключевым словам
            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                currentAds = currentAds.Where(p => p.Title.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            // Фильтр по категории
            if (CategoryComboBox.SelectedValue != null)
            {
                int selectedCategoryId = (int)CategoryComboBox.SelectedValue;
                currentAds = currentAds.Where(p => p.CategoryID == selectedCategoryId).ToList();
            }

            // Фильтр по городу
            if (CityFilter.SelectedValue != null)
            {
                int selectedCityId = (int)CityFilter.SelectedValue;
                currentAds = currentAds.Where(p => p.CityID == selectedCityId).ToList();
            }

            // Фильтр по статусу
            if (StatusFilter.SelectedValue != null)
            {
                int selectedTypeId = (int)StatusFilter.SelectedValue;
                currentAds = currentAds.Where(p => p.TypeID == selectedTypeId).ToList();
            }

            // Радиокнопки для активных/завершенных объявлений
            if (activeRb.IsChecked == true)
            {
                currentAds = currentAds.Where(p => p.StatusID == 1).ToList();
            }
            else if (finishedRb.IsChecked == true)
            {
                currentAds = currentAds.Where(p => p.StatusID == 2).ToList();
            }

            ADListBox.ItemsSource = currentAds; // Привязка данных к ListBox
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAds(); // Обновление списка объявлений
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void CityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAds();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAds();
        }
    }
}
