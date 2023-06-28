
using System;
using System.Globalization;
using Maui_Fun.Models;

namespace Maui_Fun.Helpers
{
	public class CalendarDays
	{
        public List<DayInfo> GetDaysOfWeekForCurrentWeek()
        {
            var cultureInfo = new CultureInfo("pt-BR");

            DateTime actualDate = DateTime.Now;
            DateTime startWeek = actualDate.AddDays(-(int)actualDate.DayOfWeek);
            DateTime endWeek = startWeek.AddDays(6);

            List<DayInfo> daysOfWeek = new List<DayInfo>();

            for (DateTime dia = startWeek; dia <= endWeek; dia = dia.AddDays(1))
            {
                var dayOfWeek = dia.ToString("ddd", cultureInfo).TrimEnd('.');

                var dayTitle = cultureInfo.TextInfo.ToTitleCase(dayOfWeek);

                daysOfWeek.Add(new DayInfo
                {
                    DayOfMonth = dia.Day,
                    DayOfweek = dayTitle,
                    IsSelected = dia.Day == DateTime.Now.Day? true : false,
                    BackgroundColor = dia.Day == DateTime.Now.Day ? Color.FromHex("#5449DB"): Color.FromHex("#3B3E60")
                });;
            }

            return daysOfWeek;
        }

    }
}

