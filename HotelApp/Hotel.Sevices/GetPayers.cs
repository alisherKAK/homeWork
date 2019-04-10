using Hotel.Services.Abstract;

namespace Hotel.Sevices
{
    public static class GetPayers
    {
        public static IPayer GetPayer(Payers payer)
        {
            switch (payer)
            {
                case Payers.PayPal:
                    return new PayPalPayer();
                default:
                    return new PayPalPayer();
            }
        }
    }
}
