using FullApp.Services.Interfaces;

namespace FullApp.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "New scan input is ";
        }

        public string GetMessage2()
        {
            return "Keyboard input info";
        }
    }
}
