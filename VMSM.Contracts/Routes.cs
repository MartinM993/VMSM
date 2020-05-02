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

        public static class Defect
        {
            public const string Root = ApiPrefix + "/defects";
            public const string ById = Root + "/{id}";
        }

        public static class Product
        {
            public const string Root = ApiPrefix + "/products";
            public const string ById = Root + "/{id}";
        }

        public static class FieldWorkerProduct
        {
            public const string Root = ApiPrefix + "/fieldworkerproducts";
            public const string ById = Root + "/{id}";
        }
    }
}
