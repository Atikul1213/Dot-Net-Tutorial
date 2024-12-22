using FirstCoreMVCWebApplication.Models.Services;

namespace FirstCoreMVCWebApplication.Models.ServiceCollectionDI
{
    public class Item1 : IItem
    {
        public double GetAmount()
        {
            return 100;
        }
    }
}
