using FirstCoreMVCWebApplication.Models.LazyEagerLoading.Model;

namespace FirstCoreMVCWebApplication.Models.LazyEagerLoading
{
    public class CustomerProxy : Customer
    {
        private Profile _profile;

        public override Profile? Profile
        {
            get
            {
                if (_profile == null)
                {
                    // EF Core issues SQL automatically to load the profile
                    // _profile = EFCoreLazyLoader.LoadRelatedEntity<Profile>(this.CustomerId);
                }

                return _profile;
            }

            set => _profile = value;
        }
    }
}
