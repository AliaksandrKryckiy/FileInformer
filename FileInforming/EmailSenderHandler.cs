using System;
using System.Net;
using System.Net.Mail;

namespace FileInforming.Infrastructure
{
    public class EmailSenderHandler : IEmailSenderHandler
    {
        private IEmailSender _emailSender;

        public EmailSenderHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendWithAttach(string attachFilePath)
        {
            try
            {
                _emailSender.SendWithAttach(attachFilePath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SendWithAttach(ISendingFile attachFilePath)
        {
            try
            {
                _emailSender.SendWithAttach(attachFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
