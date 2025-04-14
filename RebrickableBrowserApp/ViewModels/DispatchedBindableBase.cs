using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Dispatching;

namespace RebrickableBrowserApp.ViewModels;
public abstract class DispatchedBindableBase : INotifyPropertyChanged
{
    // Insert the event and property below here
    public event PropertyChangedEventHandler PropertyChanged;
    protected DispatcherQueue Dispatcher { get; } = DispatcherQueue.GetForCurrentThread();
    // Insert SetProperty below here
    protected virtual bool SetProperty<T>(ref T backingVariable, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingVariable, value))
        {
            return false;
        }
        backingVariable = value;
        RaisePropertyChanged(propertyName);
        return true;
    }

    // Insert RaisePropertyChanged below here
    protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        DispatchAsync(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed    }
    }
    // Insert DispatchAsync below here
    protected async Task DispatchAsync(DispatcherQueueHandler callback)
    {
        var hasThreadAccess =
#if __WASM__
    true;
#else
        Dispatcher.HasThreadAccess;
#endif

        if (hasThreadAccess)
        {
            callback.Invoke();
        }
        else
        {
            var completion = new TaskCompletionSource();
            Dispatcher.TryEnqueue(() =>
            {
                callback();
                completion.SetResult();
            });
            await completion.Task;
        }
    }
}
