using Hotel.Services.Abstract;

namespace Hotel.Sevices
{
    public static class GetSeneder
    {
        public static ISender GetSender(Senders sender)
        {
            switch (sender)
            {
                case Senders.SmsSender:
                    return new SmsSender();
                case Senders.TelegramSender:
                    return new TelegramBot();
                default:
                    return new TelegramBot();
            }
        }
    }
}
