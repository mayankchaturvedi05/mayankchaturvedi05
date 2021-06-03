using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace StratixRuanBusinessLogic
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns True if privateField was set
        /// <para>Returns false if privateField and value are equal.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="privateField"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns>True if field was set</returns>
        protected bool SetField<T>(ref T privateField, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(privateField, value))
            {
                return false;
            }

            privateField = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Returns True if privateField was set
        /// <para>Returns false if privateField and value are equal.</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="privateField"></param>
        /// <param name="value"></param>
        /// <param name="nullValue"></param>
        /// <param name="propertyName"></param>
        /// <returns>True if field was set</returns>
        protected bool SetField<T>(ref T privateField, T value, T nullValue, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (value != null && value.Equals(nullValue))
            {
                value = default(T);
            }

            if (EqualityComparer<T>.Default.Equals(privateField, value))
            {
                return false;
            }

            privateField = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
