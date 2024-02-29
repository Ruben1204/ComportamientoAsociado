using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComportamientoAsociado
{
    public static class ValidarNumeroBehavior
    {
        public static readonly BindableProperty AplicarBehaviorProperty = BindableProperty.CreateAttached("AplicarBehavior", typeof(bool), typeof(ValidarNumeroBehavior), false, propertyChanged: OnCambioComportamiento);

        public static bool GetAplicarBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AplicarBehaviorProperty);
        }

        public static void SetAplicarBehavior(BindableObject view, bool value)
        {
           view.SetValue(AplicarBehaviorProperty, value);
        }

        static void OnCambioComportamiento(BindableObject view, object oldValue, object  newValue) {
            Entry entry = view as Entry;
            if(entry == null)
            {
                return;
            }
            bool aplicarBahavior = (bool)newValue;
            if(aplicarBahavior)
            {
                entry.TextChanged +=Entry_TextChanged;
            }
            else
            {
                entry.TextChanged -=Entry_TextChanged;
            }
           }

        private static void Entry_TextChanged(object? sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Colors.Black : Colors.Red;
        }
    }
}
