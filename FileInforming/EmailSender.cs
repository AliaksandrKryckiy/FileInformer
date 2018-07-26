using FileInforming.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming
{
    public class EmailSender : IEmailSender
    {
        private MailAddress _from, _to;
        private MailMessage _mail;
        private string _address;

        ISettingManager _settingManager;        

        protected readonly string _addressSender = "kritsky.test@gmail.com";
        protected readonly string _passSender = "fileinformer";

        public EmailSender(ISettingManager settingManager) 
        {          
            _settingManager = settingManager;                           
        }

        /// <summary>
        /// Отправляет файл с вложением
        /// </summary>
        /// <param name="attachFile">Объект ISendingFile</param>
        public void SendWithAttach(ISendingFile attachFile)
        {
            try
            {
                _address = _settingManager.GetParam("address").ToString();
                _from = new MailAddress(_address, _settingManager.GetParam("displayName").ToString());
                _to = new MailAddress(_address);
                _mail = new MailMessage(_from, _to);
                _mail.Subject = _settingManager.GetParam("messageSubject").ToString();
                _mail.Body = _settingManager.GetParam("messageBody").ToString();
                _mail.Attachments.Add(new Attachment(attachFile.Path));

                SmtpClient smtp = new SmtpClient(_settingManager.GetParam("host").ToString(), Convert.ToInt32(_settingManager.GetParam("port")));
                smtp.Credentials = new NetworkCredential(_addressSender, _passSender);
                smtp.EnableSsl = true;

                smtp.Send(_mail);
                _mail.Dispose();                
            }
            catch (ObjectDisposedException ex)
            {                
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw ex;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Отправляет файл с вложением
        /// </summary>
        /// <param name="attachFilePath">Строковый путь к файлу</param>
        public void SendWithAttach(string attachFilePath)
        {
            try
            {
                _address = _settingManager.GetParam("address").ToString();
                _from = new MailAddress(_address, _settingManager.GetParam("displayName").ToString());
                _to = new MailAddress(_address);
                _mail = new MailMessage(_from, _to);
                _mail.Subject = _settingManager.GetParam("messageSubject").ToString();
                _mail.Body = _settingManager.GetParam("messageBody").ToString();
                _mail.Attachments.Add(new Attachment(attachFilePath));

                SmtpClient smtp = new SmtpClient(_settingManager.GetParam("host").ToString(), Convert.ToInt32(_settingManager.GetParam("port")));
                smtp.Credentials = new NetworkCredential(_addressSender, _passSender);
                smtp.EnableSsl = true;

                smtp.Send(_mail);
                _mail.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw ex;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
