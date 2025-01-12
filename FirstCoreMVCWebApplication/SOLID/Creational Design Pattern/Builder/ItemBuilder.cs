namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Builder
{
    public class ItemBuilder
    {
        private Item _item;
        public ItemBuilder()
        {
            _item = new Item();
        }

        public void SetValue1(string itemValue)
        {
            _item.value1 = itemValue;
        }

        public void SetValue2(string itemValue)
        {
            _item.value2 = itemValue;
        }

        public void SetValue3(string itemValue)
        {
            _item.value3 = itemValue;
        }

        public Item GetItem()
        {
            return _item;
        }
    }
}
