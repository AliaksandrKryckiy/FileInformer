using Castle.DynamicProxy;
using FileInforming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming
{
    public class Interceptor : IInterceptor
    {
        private readonly IFileLogger _logger;

        public Interceptor(IFileLogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;           

            StringBuilder methodArgs = new StringBuilder();

            foreach (var arg in invocation.Arguments)
                methodArgs.Append(arg.ToString()).Append("  ");            
            
            _logger.AddToOutput($"Method name: {methodName} with args: {methodArgs}");//            

            try
            {
                invocation.Proceed();

                if (invocation.InvocationTarget is IEmailSender && methodName == "SendWithAttach")
                    _logger.AddToConsole("Письмо отправлено");
            }
            catch (Exception ex)
            {
                _logger.AddToOutput($"Method name: {methodName} with args: {methodArgs}. Error message: {ex.Message}");//
                _logger.AddToConsole($"Method name: {methodName} with args: {methodArgs}. Error message: {ex.Message}");//
                _logger.AddToLog($"Method name: {methodName} with args {methodArgs}", ex);
            }
        }
    }
}
