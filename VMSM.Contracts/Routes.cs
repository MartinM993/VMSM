namespace VMSM.Contracts
{
    public static class Routes
    {
        internal const string ApiPrefix = "api";

        public static class User
        {
            public const string Root = ApiPrefix + "/users";
            public const string ById = Root + "/{id}";
            public const string CurrentLoggedUser = Root + "/currentloggeduser";
            public const string ChangeRole = Root + "/changerole";
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

        public static class Income
        {
            public const string Root = ApiPrefix + "/incomes";
            public const string ById = Root + "/{id}";
        }

        public static class Schedule
        {
            public const string Root = ApiPrefix + "/schedules";
            public const string ById = Root + "/{id}";
            public const string RemoveVM = Root + "/removevm/{id}";
        }

        public static class StorageExport
        {
            public const string Root = ApiPrefix + "/storageexports";
            public const string ById = Root + "/{id}";
        }

        public static class StorageImport
        {
            public const string Root = ApiPrefix + "/storageimports";
            public const string ById = Root + "/{id}";
        }

        public static class Vehicle
        {
            public const string Root = ApiPrefix + "/vehicles";
            public const string ById = Root + "/{id}";
            public const string WithoutUser = ApiPrefix + "/vehicleswithoutuser";
        }

        public static class VendingMachineProduct
        {
            public const string Root = ApiPrefix + "/vendingmachineproducts";
            public const string ById = Root + "/{id}";
        }

        public static class VendingMachineProductPrice
        {
            public const string Root = ApiPrefix + "/vendingmachineproductprices";
            public const string ById = Root + "/{id}";
        }

        public static class Account
        {
            public const string Login = ApiPrefix + "/login";
            public const string Logout = ApiPrefix + "/logout";
            public const string ChangePassword = ApiPrefix + "/changepassword";
        }

        public static class Report
        {
            public const string Root = ApiPrefix + "/report";
        }
    }
}
