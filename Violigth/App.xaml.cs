using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Violigth.Client;
using Violigth.Data.Repository;
using Violigth.Data.Repository.Interface;

namespace Violigth
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IItemRepository, ItemRepository>();
            unityContainer.RegisterType<ITypeRepository, TypeRepository>();

            Administrator window = unityContainer.Resolve<Administrator>();
            window.Show();
        }
    }
}
