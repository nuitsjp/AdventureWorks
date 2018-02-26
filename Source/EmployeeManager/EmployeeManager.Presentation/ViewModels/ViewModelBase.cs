using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;

namespace AdventureWorks.EmployeeManager.Presentation.ViewModels
{
    public abstract class ViewModelBase : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive { get; private set; } = true;

        protected void RequestNavigate<TViewModel>(IRegionManager regionManager)
            where TViewModel : ViewModelBase
        {
            var typeName = typeof(TViewModel).Name;
            var viewName = typeName.Substring(0, typeName.Length - "ViewModel".Length);
            regionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
        }

        protected void Pop(IRegionManager regionManager)
        {
            var journal = regionManager.Regions[RegionNames.ContentRegion].NavigationService.Journal;
            if (journal.CanGoBack)
            {
                KeepAlive = false;
                journal.GoBack();
            }
        }
    }
}
