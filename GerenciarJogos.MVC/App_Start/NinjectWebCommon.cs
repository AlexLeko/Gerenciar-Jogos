
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GerenciarJogos.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GerenciarJogos.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace GerenciarJogos.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Domain.Services;
    using Domain.Interface.Repositories;
    using Application.Interface;
    using Application.Service;
    using Domain.Interface.Services;
    using Infra.Data.Repositories;
    using Domain.Interface.Domain;
    using Domain.EmprestimoBusiness;


    /// <summary>
    /// Bootstrapper for the application.
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            #region [AppService]
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(IAppServiceBase<>));
            kernel.Bind<ITipoConsoleAppService>().To<TipoConsoleAppService>();
            kernel.Bind<IJogoAppService>().To<JogoAppService>();
            kernel.Bind<IAmigoAppService>().To<AmigoAppService>();
            kernel.Bind<IEmprestimoAppService>().To<EmprestimoAppService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();

            #endregion

            #region [Service]
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ITipoConsoleService>().To<TipoConsoleService>();
            kernel.Bind<IJogoService>().To<JogoService>();
            kernel.Bind<IAmigoService>().To<AmigoService>();
            kernel.Bind<IEmprestimoService>().To<EmprestimoService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();

            kernel.Bind<IEmprestimoBusiness>().To<EmprestimoBusiness>();

            #endregion

            #region [Repository]
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ITipoConsoleRepository>().To<TipoConsoleRepository>();
            kernel.Bind<IJogoRepository>().To<JogoRepository>();
            kernel.Bind<IAmigoRepository>().To<AmigoRepository>();
            kernel.Bind<IEmprestimoRepository>().To<EmprestimoRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();


            #endregion

        }
    }

}
