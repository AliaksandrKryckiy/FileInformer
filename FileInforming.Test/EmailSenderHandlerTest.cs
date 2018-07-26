using FileInforming.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileInforming.Test
{
    [TestFixture]
    public class EmailSenderHandlerTest
    {
        [Test]
        public void SendEmailWithAttach_ExpectedOnce()
        {
            var emailSenderMoq = new Mock<IEmailSender>();
            var sendingFileMoq = new Mock<ISendingFile>();

            emailSenderMoq.Setup(f => f.SendWithAttach(sendingFileMoq.Object)).Verifiable();

            var test = new EmailSenderHandler(emailSenderMoq.Object);

            test.SendWithAttach(sendingFileMoq.Object);

            emailSenderMoq.Verify(h => h.SendWithAttach(sendingFileMoq.Object), Times.Once);
        }

        [Test]
        public void SendEmailWithAttach_ExpectedOnce_String()
        {
            var emailSenderMoq = new Mock<IEmailSender>();
            emailSenderMoq.Setup(f => f.SendWithAttach("somestring")).Verifiable();

            var test = new EmailSenderHandler(emailSenderMoq.Object);
            test.SendWithAttach("somestring");

            emailSenderMoq.Verify(h => h.SendWithAttach("somestring"), Times.Once);
        }
    }
}
