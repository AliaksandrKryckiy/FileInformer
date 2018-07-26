namespace FileInforming.Infrastructure
{
    public interface IEmailSenderHandler
    {
        void SendWithAttach(ISendingFile attachFilePath);
        void SendWithAttach(string attachFilePath);
    }
}
