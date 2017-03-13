using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CQ.Controls
{
    public class CarouselViewExpand : CarouselView
    {

        //public static readonly BindableProperty PeriodProperty = BindableProperty.Create("Period", typeof(double), typeof(MyCarouselView), 3000);
        //public double Period
        //{
        //    get { return (double)GetValue(PeriodProperty); }
        //    set { SetValue(PeriodProperty, value); }
        //}

        #region CarouselView轮播

        public static readonly BindableProperty AutoPlayProperty = BindableProperty.Create("AutoPlay", typeof(bool?), typeof(CarouselViewExpand), null, propertyChanged: AutoPlayBindingPropertyChanged);
        public bool? AutoPlay
        {
            get { return (bool?)this.GetValue(AutoPlayProperty); }
            set
            {
                SetValue(AutoPlayProperty, value);
            }
        }

        private static int _itemsCount = 0;
        private static CarouselView _cv;
        public static void AutoPlayBindingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue == true)
            {
                CarouselView cv = bindable as CarouselView;
                _cv = cv;
                //var period = (double?)cv.GetValue(PeriodProperty);
                //if (period == null)
                //{
                //    period = 2000;
                //}
                double period = 3000;
                Device.StartTimer(System.TimeSpan.FromMilliseconds(period), () =>
                {
                    IList list = _cv.ItemsSource as IList;
                    _itemsCount = list.Count;
                    if (_itemsCount == 0)
                        return false;
                    _cv.Position = (_cv.Position + 1) % _itemsCount;

                    var re = (bool)_cv.GetValue(AutoPlayProperty);
                    return re;
                });
            }
        }

        #endregion
    }
}
