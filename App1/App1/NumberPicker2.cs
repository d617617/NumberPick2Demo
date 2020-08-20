using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class NumberPicker2 : View
    {


        public Color SelectedColor { get; set; } = Color.Red;

        public Color UnSelectedTextColor { get; set; } = Color.Blue;


        public double FontSize { get; set; } = 40;



        public event Action<object, EventArgs> CurrentItemChanged;        

        /// <summary>
        /// mvvm 选中的值
        /// </summary>
        public static readonly BindableProperty CurrentItemProperty =
      BindableProperty.Create(nameof(CurrentItem), typeof(string), typeof(NumberPicker2), default(string)
          , propertyChanged: (obj, o, n) =>
            {
                (obj as NumberPicker2).CurrentItemPropertyChanged();
            });

        void CurrentItemPropertyChanged()
        {
            CurrentItemChanged?.Invoke(this, new EventArgs());
        }

        

        public string CurrentItem
        {
            get { return (string)GetValue(CurrentItemProperty); }
            set
            {              
                SetValue(CurrentItemProperty, value);
            }
        }



    }
}