using FullApp.Core.EventAggregtor;
using FullApp.Core.SystemEventsArgs;
using FullApp.SharedServices.Interface;
using Prism.Events;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Interop;

namespace FullApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "PrismDemoApp";
        private readonly IKeyloggerService _keylogger;
        private readonly IEventAggregator _ea;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IKeyloggerService keyloggerService, IEventAggregator ea)
        {
            _keylogger = keyloggerService;
            _ea = ea;

            Application.Current.MainWindow.Loaded += MainWindow_Loaded;
            Application.Current.MainWindow.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            _keylogger.KeyboardUnregistered();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var shell = (Window)sender;
            _keylogger.KeyboardRegisteredAndHook(new WindowInteropHelper(shell).EnsureHandle());
            _keylogger.NewKeyboardEvent += Keylogger_NewKeyboardEvent;
        }

        private void Keylogger_NewKeyboardEvent(object sender, System.EventArgs e)
        {
            KeyboardEventArgs newScan = (KeyboardEventArgs) e;
            _ea.GetEvent<NewScanEvent>().Publish(newScan);
        }
    }
}