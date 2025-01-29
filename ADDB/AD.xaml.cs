using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            listview.ItemsSource = Entities.GetContext().Advertisement.ToList();
            UpdateAds();
        }

        /*        private void UpdateAds()
                {
                    var currentAds = Entities.GetContext().Advertisement.ToList();

                    // Фильтр по ключевым словам

                    currentAds = currentAds.Where(p => p.Title.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();


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

                    ADList.ItemsSource = currentAds; // Привязка данных к ListBox
                }*/
        private void UpdateAds()
        {
            var currentAds = Entities.GetContext().Advertisement.ToList();

            // Поиск по наименованию
            currentAds = currentAds.Where(p => p.Title.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();



            if (CategoryComboBox.SelectedValue != null)
            {
                int selectedCategoryId = (int)CategoryComboBox.SelectedValue;
                currentAds = currentAds.Where(p => p.CategoryID == selectedCategoryId).ToList();
            }

            if (CityFilter.SelectedValue != null)
            {
                int selectedCityId = (int)CityFilter.SelectedValue;
                currentAds = currentAds.Where(p => p.CityID == selectedCityId).ToList();
            }

            if (StatusFilter.SelectedValue != null)
            {
                int selectedTypeId = (int)StatusFilter.SelectedValue;
                currentAds = currentAds.Where(p => p.TypeID == selectedTypeId).ToList();
            }

            if (activeRb.IsChecked == true)
            {
                currentAds = currentAds.Where(p => p.StatusID == 1).ToList();
            }
            else
            {
                currentAds = currentAds.Where(p => p.StatusID == 2).ToList();
            }



            listview.ItemsSource = currentAds;
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
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            CategoryComboBox.SelectedValue = null;
            CityFilter.SelectedValue = null;
            StatusFilter.SelectedValue = null;
            activeRb.IsChecked = true;
        }
        private void ADList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedAd = (Advertisement)listview.SelectedItem;
            if (selectedAd != null)
            {
                NavigationService.Navigate(new EditAdPage(selectedAd));
            }
        }
    }
}
