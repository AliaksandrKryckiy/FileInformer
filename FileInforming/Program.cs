using System;
using Castle.DynamicProxy;
using FileInforming.Infrastructure;
using Ninject;

namespace FileInforming
{
    class Program
    {
        static void Main()
        {
            var kernel = InitNinject();            
            var fileInformer = kernel.Get<IFileInformer>();
  
            Console.WriteLine("Что бы выйти из программы нажмите \'q\'");            
                
            fileInformer.Run();

            while (Console.Read() != 'q') ;
            fileInformer.Dispose();
        }

        private static StandardKernel InitNinject()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ISendingFile>().To<SendingFile>();
            kernel.Bind<IFileLogger>().To<FileLogger>().InSingletonScope();

            kernel.Bind<IFileManager>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var fileManager = new FileManager();
                return builder.CreateInterfaceProxyWithTarget<IFileManager>(
                    fileManager,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            kernel.Bind<ISettingManager>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var settings = new SettingManager();
                return builder.CreateInterfaceProxyWithTarget<ISettingManager>(
                    settings,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });           

            kernel.Bind<IEmailSender>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var emailSender = new EmailSender(kernel.Get<ISettingManager>());
                return builder.CreateInterfaceProxyWithTarget<IEmailSender>(
                    emailSender,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });
            kernel.Bind<IEmailSenderHandler>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var emailSender = new EmailSenderHandler(kernel.Get<IEmailSender>());
                return builder.CreateInterfaceProxyWithTarget<IEmailSenderHandler>(
                    emailSender,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            kernel.Bind<IFileWatcher>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var fileWatcher = new FileWatcher(kernel.Get<ISendingFile>());
                return builder.CreateInterfaceProxyWithTarget<IFileWatcher>(
                    fileWatcher,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            kernel.Bind<IFileWatcherHandler>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var fileWatcherHandler = new FileWatcherHandler(kernel.Get<IFileWatcher>());
                return builder.CreateInterfaceProxyWithTarget<IFileWatcherHandler>(
                    fileWatcherHandler,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            kernel.Bind<IFileInformer>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var fileInformer = new FileInformer(kernel.Get<IFileWatcherHandler>(), kernel.Get<IEmailSenderHandler>() ,kernel.Get<IFileManager>(), kernel.Get<ISettingManager>());
                return builder.CreateInterfaceProxyWithTarget<IFileInformer>(
                    fileInformer,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            return kernel;
        }
    }
}