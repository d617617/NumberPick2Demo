using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using SuperRabbit.Lib;
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
        }


    }

    class DaysAdapter : Java.Lang.Object, IWheelAdapter
    {
        public int MaxIndex => 30;

        public int MinIndex => 0;

        public string TextWithMaximumLength => "31";

        public int GetPosition(string value)
        {
            return int.Parse(value)-1;
        }

        public string GetValue(int position)
        {
            if (position==-2)
            {
                return "30";
            }
            if (position == -1)
            {
                return "31";
            }
            return (position+1).ToString();
        }
    }
}