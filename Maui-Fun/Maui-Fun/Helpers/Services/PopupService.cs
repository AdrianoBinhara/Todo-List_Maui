using System;
using Maui_Fun.Helpers.Interfaces;
using Mopups.Pages;
using Mopups.Services;

namespace Maui_Fun.Helpers.Services
{
	public class PopupService:IPopupService
	{
        public void ShowPopup(PopupPage popup)
        {
            MopupService.Instance.PushAsync(popup);
        }
    }
}

