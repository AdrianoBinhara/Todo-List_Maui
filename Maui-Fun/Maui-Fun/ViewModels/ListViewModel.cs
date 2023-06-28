using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Maui_Fun.Helpers;
using Maui_Fun.Helpers.Interfaces;
using Maui_Fun.Models;
using Maui_Fun.Views;
using Mopups.Interfaces;

namespace Maui_Fun.ViewModels
{
	public class ListViewModel : BaseViewModel
	{
        #region Properties
        private IPopupNavigation _popupNavigation;

        public ObservableCollection<Item> AllItems { get; set; } = new ObservableCollection<Item>();

        private ObservableCollection<Item> _visibleItems;
        public ObservableCollection<Item> VisibleItems
        {
            get { return _visibleItems; }
            set { SetProperty(ref _visibleItems, value); }
        } 
        public string CurrentDay { get; set; }
        public DayInfo SelectedDay { get; set; }

        public ObservableCollection<DayInfo> Week { get; set; }

        #endregion


        public ListViewModel(IPopupNavigation popupNavigation)
		{
            _popupNavigation = popupNavigation;
            VisibleItems = new ObservableCollection<Item>();
            GetCurrentWeek();
            GetCurrentDayOfWeek();
            PopulateList();
            UpdateVisibleItems();
            SelectDayCommand = new Command<DayInfo>((dayInfo) =>SelectDayExecute(dayInfo));
            AddItemCommand = new Command(() => AddItemExecute());

        }

        


        #region Commands
        public ICommand SelectDayCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        #endregion


        #region Methods
        private void AddItemExecute()
        {
            _popupNavigation.PushAsync(new AddItemPopupPage());
        }
        private void SelectDayExecute(DayInfo dayInfo)
        {
            SelectedDay = dayInfo;

            foreach (var day in Week)
            {
                day.IsSelected = day == dayInfo;
                day.BackgroundColor = day.IsSelected ? Color.FromHex("#5449DB") : Color.FromHex("#3B3E60");

            }

            UpdateVisibleItems();

        }
        private void UpdateVisibleItems()
        {
            var tasksForSelectedDay = AllItems.Where(t => t.ScheduledDate == SelectedDay.DayOfMonth).ToList();

            var newVisibleItems = new ObservableCollection<Item>(tasksForSelectedDay);

            VisibleItems = newVisibleItems;
        }
        private void GetCurrentWeek()
        {
            CalendarDays calendar = new CalendarDays();
            
            Week =new ObservableCollection<DayInfo>(calendar.GetDaysOfWeekForCurrentWeek());
        }

        private void GetCurrentDayOfWeek()
        {
            var day = DateTime.Now;
            var month = day.ToString("MMM", new CultureInfo("pt-BR")).TrimEnd('.');
            var monthTitle = new CultureInfo("pt-BR").TextInfo.ToTitleCase(month); 
            CurrentDay = $"{day.Day}, {day.DayOfWeek} {monthTitle}";
            SelectedDay = Week.FirstOrDefault(x=>x.IsSelected);

        }

        private void PopulateList()
        {
			AllItems = new ObservableCollection<Item>()
			{
				new Item
				{
					 Title = "Jogar",
					 Description = "Valorant",
                     ScheduledDate = SelectedDay.DayOfMonth,
					 Time = DateTime.Now
				},
                new Item
                {
                     Title = "Trein",
                     Description = "Jiu Jitsu",
                     ScheduledDate = SelectedDay.DayOfMonth,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 18,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 18,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 22,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 19,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 19,
                     Time = DateTime.Now
                },new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 20,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 20,
                     Time = DateTime.Now
                },new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 22,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 23,
                     Time = DateTime.Now
                },
                 new Item
                {
                     Title = "Academia",
                     Description = "Treino de peito",
                     ScheduledDate = 24,
                     Time = DateTime.Now
                },
                new Item
                {
                     Title = "Jogar",
                     Description = "Valorant",
                     ScheduledDate = 24,
                     Time = DateTime.Now
                },
            };
        }
        #endregion
    }
}

