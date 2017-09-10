using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Clinic.ViewModels.Base
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MagicAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class NoMagicAttribute : Attribute
    {
    }

    [Magic]
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [MethodImpl(MethodImplOptions.NoInlining)] // to preserve method call 
        protected static void Raise()
        {
        }
    }
}