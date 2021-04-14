using LibraryWebAPI.Services;
using System;
using Unity;
using Unity.Injection;

namespace LibraryWebAPI
{
    public class UnityDiContainerProvider
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBooksService, BooksService>();
            container.RegisterType<IDbService, DbService>();
            container.RegisterType<Func<IAppDbContext>>(
                new InjectionFactory(ctx => new Func<IAppDbContext>(() => new AppDbContext())));

            return container;
        }
    }
}
