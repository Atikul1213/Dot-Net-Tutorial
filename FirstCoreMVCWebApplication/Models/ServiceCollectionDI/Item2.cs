using FirstCoreMVCWebApplication.Models.Services;

namespace FirstCoreMVCWebApplication.Models.ServiceCollectionDI
{
    public class Item2 : IItem
    {
        public double GetAmount()
        {
            return 200;
        }
    }
}
