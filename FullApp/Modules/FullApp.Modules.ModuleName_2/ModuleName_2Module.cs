using FullApp.Core;
using FullApp.Modules.ModuleName_2.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FullApp.Modules.ModuleName_2
{
    public class ModuleName_2Module : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleName_2Module(IRegionManager regionManager) 
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion2, "ViewB");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}