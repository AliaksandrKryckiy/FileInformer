namespace FileInforming.Infrastructure
{
    public interface IEmailSender
    { 
        void SendWithAttach(ISendingFile attachFile);
        void SendWithAttach(string attachFilePath);        
    }
}
