namespace VMSM.Contracts
{
    public static class Routes
    {
        internal const string ApiPrefix = "api";

        public static class User
        {
            public const string Root = ApiPrefix + "/users";
            public const string ById = Root + "/{id}";
        }

        public static class Address
        {
            public const string Root = ApiPrefix + "/addresses";
            public const string ById = Root + "/{id}";
        }

        public static class VendingMachine
        {
            public const string Root = ApiPrefix + "/vendingmachines";
            public const string ById = Root + "/{id}";
        }
    }
}
