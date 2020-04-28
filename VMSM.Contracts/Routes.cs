namespace VMSM.Contracts
{
    public static class Routes
    {
        internal const string ApiPrefix = "api";

        public static class Test
        {
            public const string Root = ApiPrefix + "/test";
        }

        public static class User
        {
            public const string Root = ApiPrefix + "/users";
            public const string ById = Root + "/{id}";
        }
    }
}
