namespace AG.PaymentApp.Domain.Core.ValueObject
{
    public class Country
    {
        public static Country Default = new UnitedKingdom();

        public Country()
        { }

        protected Country(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        public string Name { get; set; }
        public string Code { get; set; }

        public class UnitedKingdom : Country
        {
            public static UnitedKingdom Instance = new UnitedKingdom();

            public UnitedKingdom()
                : base("United Kingdom", "UK")
            {
            }
        }

        public class Portugal : Country
        {
            public static Portugal Instance = new Portugal();

            public Portugal()
                : base("Portugal", "PT")
            {
            }
        }

        public class Brazil : Country
        {
            public static Brazil Instance = new Brazil();

            public Brazil()
            : base("Brazil", "BRL")
            {
            }
        }
    }
}
