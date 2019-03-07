using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.Identity;
using ProductsStore.BLL.Infrastructure;
using ProductsStore.BLL.Interfaces;
using ProductsStore.BLL.Services;
using SimpleInjector;

namespace ProductsStore.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static Container container;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Injector();
            Application.Run(container.GetInstance<Main>());
        }

        private static void Injector()
        {
            container = new Container();

            container.Register<IUserService, UserService>();
            container.Register<IShipmentService, ShipmentService>();
            container.Register<Main>();
            //container.Register<Login>();
            //container.Register<ChangePassword>();

            new ServiceModule(container);
        }
    }
}
