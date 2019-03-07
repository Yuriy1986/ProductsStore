using SimpleInjector;
using ProductsStore.DAL.Interfaces;
using ProductsStore.DAL.Repositories;

namespace ProductsStore.BLL.Infrastructure
{
    public class ServiceModule
    {
        public ServiceModule(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>();
        }
    }
}
