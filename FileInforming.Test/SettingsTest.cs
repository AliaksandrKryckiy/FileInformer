using Castle.DynamicProxy;
using FileInforming.Infrastructure;
using Ninject;
using NUnit.Framework;
using System;

namespace FileInforming.Test
{
    [TestFixture]
    public class SettingsTest
    {
        [Test]
        public void GetSetting_Port_WithInterceptor_ExpectedPass()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFileLogger>().To<FileLogger>();
            kernel.Bind<ISettingManager>().ToMethod(ctx =>
            {
                var builder = new ProxyGenerator();
                var settings = new SettingManager();
                return builder.CreateInterfaceProxyWithTarget<ISettingManager>(
                    settings,
                    new Interceptor(ctx.Kernel.Get<IFileLogger>()));
            });

            string expected = kernel.Get<ISettingManager>().GetParam("port").ToString();

            Assert.AreEqual("587", expected);
        }

        [Test]
        public void GetSetting_Port_ExpectedPass()
        {
            var settings = new SettingManager();
            string expected = settings.GetParam("port").ToString();

            Assert.AreEqual("587", expected);
        }

        [Test]
        public void GetSetting_Port_ExpectedException()
        {
            var settings = new SettingManager();

            Assert.Throws<NullReferenceException>(() => settings.GetParam("ports"));
        }
    }
}
