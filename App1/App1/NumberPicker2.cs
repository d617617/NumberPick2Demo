using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class NumberPicker2 : View
    {
        public int SelectedIndex { get; set; }

        public Color SelectedColor { get; set; } = Color.Red;

        public Color UnSelectedTextColor { get; set; } = Color.Blue;

        public double FontSize { get; set; } = 40;
    }
}