using FullApp.Core.EventAggregtor;
using FullApp.Core.Mvvm;
using FullApp.Core.SystemEventsArgs;
using FullApp.Services.Interfaces;
using Prism.Events;
using Prism.Regions;
using System;

namespace FullApp.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        private string _keyboard_input;
        
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string KeyboardInput 
        {
            get { return _keyboard_input; }
            set { SetProperty(ref _keyboard_input, value);  }
        }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService, IEventAggregator ea) : base(regionManager)
        {
            Message = messageService.GetMessage();
            ea.GetEvent<NewScanEvent>().Subscribe(NewScanReceived);
        }

        private void NewScanReceived(KeyboardEventArgs input)
        {
            KeyboardInput = input.Text;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
