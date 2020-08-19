using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using App1.Droid;
using SuperRabbit.Lib;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(App1.NumberPicker2), typeof(NumberPickerRender))]
namespace App1.Droid
{
    public class NumberPickerRender : ViewRenderer<NumberPicker2, WheelPicker>
    {
        public NumberPickerRender(Context context) : base(context)
        {

        }


        WheelPicker wheelPicker;

        protected override void OnElementChanged(ElementChangedEventArgs<NumberPicker2> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                // Unsubscribe

            }
            if (e.NewElement != null)
            {
                var ele = e.NewElement;
                if (Control == null)
                {
                    wheelPicker = new WheelPicker(Context);
                    SetNativeControl(wheelPicker);

                }// Subscribe              

            }
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            wheelPicker.SetWheelItemCount(3);
            wheelPicker.SetAdapter(new DaysAdapter());
            wheelPicker.SetMin(0);
            wheelPicker.SetSelectorRoundedWrapPreferred(true);
            wheelPicker.ValueChange += WheelPicker_ValueChange;
            wheelPicker.SetSelectedTextColor(Resource.Color.custmonColor);
            //开始反射
            var fss = wheelPicker.Class.GetDeclaredFields();
            var _class = wheelPicker.Class;
            var des = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;
            var sizeField = _class.GetDeclaredField("mTextSize");
            sizeField.Accessible = true;
            sizeField.Set(wheelPicker, (int)Math.Ceiling(Element.FontSize * des));
            var selecedColorField = _class.GetDeclaredField("mSelectedTextColor");
            selecedColorField.Accessible = true;
            selecedColorField.Set(wheelPicker, (int)Element.SelectedColor.ToAndroid());
            var unselecedColorField = _class.GetDeclaredField("mUnSelectedTextColor");
            unselecedColorField.Accessible = true;
            unselecedColorField.Set(wheelPicker, (int)Element.UnSelectedTextColor.ToAndroid());
        }

        private void WheelPicker_ValueChange(object sender, ValueChangeEventArgs e)
        {
            Element.SelectedIndex = int.Parse(e.NewVal) - 1;

        }
    }

    class DaysAdapter : Java.Lang.Object, IWheelAdapter
    {
        public int MaxIndex => 30;

        public int MinIndex => 0;

        public string TextWithMaximumLength => "31";

        public int GetPosition(string value)
        {
            return int.Parse(value) - 1;
        }

        public string GetValue(int position)
        {
            if (position == -2)
            {
                return "30";
            }
            if (position == -1)
            {
                return "31";
            }
            return (position + 1).ToString();
        }
    }
}