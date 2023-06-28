using CommunityToolkit.Maui.Alerts;
using Maui_Fun.Context;
using Maui_Fun.Helpers;
using Maui_Fun.Models;
using Maui_Fun.Views;
using Mopups.Interfaces;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Maui_Fun.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        #region Properties

        private ItemRepository _itemRepository;

        private IPopupNavigation _popupNavigation;

        private ObservableCollection<Item> _visibleItems;
        public ObservableCollection<Item> VisibleItems
        {
            get { return _visibleItems; }
            set { SetProperty(ref _visibleItems, value); }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }

        public string CurrentDay { get; set; }
        public DayInfo SelectedDay { get; set; }

        public ObservableCollection<DayInfo> Week { get; set; }
        #endregion


        public ListViewModel(IPopupNavigation popupNavigation, ItemRepository itemRepository)
        {
            _popupNavigation = popupNavigation;
            VisibleItems = new ObservableCollection<Item>();
            SelectDayCommand = new Command<DayInfo>((dayInfo) => SelectDayExecute(dayInfo));
            AddItemCommand = new Command(() => AddItemExecute());
            NewItemCommand = new Command(() => NewItemExecute());
            _itemRepository = itemRepository;
            GetCurrentWeek();
            GetCurrentDayOfWeek();
            LoadList();
        }




        #region Commands
        public ICommand SelectDayCommand { get; set; }

        public ICommand AddItemCommand { get; set; }

        public ICommand NewItemCommand { get; set; }
        #endregion


        #region Methods
        private void AddItemExecute()
        {
            _popupNavigation.PushAsync(new AddItemPopupPage(this));
        }

        private async void NewItemExecute()
        {
            var item = new Item
            {
                Title = Title,
                Description = Description,
                ScheduledDate = SelectedDay.DayOfMonth,
                Time = DateTime.Now
            };

            _itemRepository.SaveItem(item);

            Title = string.Empty;

            Description = string.Empty;

            var toast = Toast.Make("Nota criada com sucesso", CommunityToolkit.Maui.Core.ToastDuration.Short, 14);

            await toast.Show();

            await _popupNavigation.PopAsync();

            LoadList();

        }
        private void SelectDayExecute(DayInfo dayInfo)
        {
            SelectedDay = dayInfo;

            foreach (var day in Week)
            {
                day.IsSelected = day == dayInfo;
                day.BackgroundColor = day.IsSelected ? Color.FromArgb("#5449DB") : Color.FromArgb("#3B3E60");

            }

            LoadList();

        }

        private void GetCurrentWeek()
        {
            CalendarDays calendar = new CalendarDays();

            Week = new ObservableCollection<DayInfo>(calendar.GetDaysOfWeekForCurrentWeek());
        }

        private void GetCurrentDayOfWeek()
        {
            var day = DateTime.Now;
            var month = day.ToString("MMM", new CultureInfo("pt-BR")).TrimEnd('.');
            var monthTitle = new CultureInfo("pt-BR").TextInfo.ToTitleCase(month);
            CurrentDay = $"{day.Day}, {day.DayOfWeek} {monthTitle}";
            SelectedDay = Week.FirstOrDefault(x => x.IsSelected);

        }

        private void LoadList()
        {
            var item = new Item();

            var seedItems = item.SeedList(SelectedDay.DayOfMonth);

            _itemRepository.AddRangeItems(seedItems);

            var itemsVisible = _itemRepository.GetVisibleItems(SelectedDay.DayOfMonth);

            VisibleItems = new ObservableCollection<Item>(itemsVisible);
        }
        #endregion
    }
}

