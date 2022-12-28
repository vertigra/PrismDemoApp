using FullApp.Core.EventAggregtor;
using FullApp.Core.Mvvm;
using FullApp.Core.SystemEventsArgs;
using FullApp.Services.Interfaces;
using Prism.Events;
using Prism.Regions;
using System;

namespace FullApp.Modules.ModuleName_2.ViewModels
{
    public class ViewBViewModel : RegionViewModelBase
    {
        private string _message;
        private string _keboard_input_info;
        public string _database_message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string KeboardInputInfo
        {
            get { return _keboard_input_info; }
            set { SetProperty(ref _keboard_input_info, value); }
        }

        public string DatabaseMessage
        {
            get { return _database_message; }
            set { SetProperty(ref _database_message, value); }
        }

        public ViewBViewModel(IRegionManager regionManager, IMessageService messageService, IDatabaseService databaseService, IEventAggregator ea) :
            base(regionManager)
        {
            Message = messageService.GetMessage2();
            DatabaseMessage = databaseService.GetDataFromDatabase1();
            ea.GetEvent<NewScanEvent>().Subscribe(NewScanReceived);
        }

        private void NewScanReceived(KeyboardEventArgs input)
        {
            KeboardInputInfo = 
                $"ProductName {input.RawInputDevice.ProductName} \n" +
                $"ProductId {input.RawInputDevice.ProductId} \n" +
                $"ManufacturerName {input.RawInputDevice.ManufacturerName} \n" +
                $"VendorId {input.RawInputDevice.VendorId} \n" +
                $"Handle {input.RawInputDevice.Handle} \n" +
                $"Handle {input.RawInputDevice.DevicePath}  \n" +
                $"DeviceType {input.RawInputDevice.DeviceType}  \n";

        }
    }
}
