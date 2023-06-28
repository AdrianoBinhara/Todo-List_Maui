using System;
namespace Maui_Fun.Helpers
{
    public class AnimatedViewCell : Grid
    {

        private bool _isAlreadyLoaded;
        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (!_isAlreadyLoaded)
            {
                this.TranslationX = 300;
                this.Opacity = 0; 

                Task.Run(async () =>
                {
                    await Task.Delay(2);
                    await this.Dispatcher.DispatchAsync(async () =>
                    {
                        await Task.WhenAll(
                            this.TranslateTo(0, 0, 500, Easing.CubicOut),
                            this.FadeTo(1, 500) 
                        );
                    });
                });

                _isAlreadyLoaded = true;
            }

        }
    }
 }

