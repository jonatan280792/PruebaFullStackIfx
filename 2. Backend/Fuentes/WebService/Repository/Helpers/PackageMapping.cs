namespace Repository.Helpers
{
    public static class STORE_PROCEDURES
    {
        // CRUD Entidades
        public static string GET_ENTIDADES = "dbo.get_Entidades";
        public static string SET_ENTIDADES = "dbo.set_Entidades";
        public static string PUT_ENTIDADES = "dbo.put_Entidades";
        public static string DELETE_ENTIDADES = "dbo.delete_Entidades";

        // CRUD Empleados
        public static string GET_EMPLEADOS = "dbo.get_Empleados";
        public static string SET_EMPLEADOS = "dbo.set_Empleados";
        public static string PUT_EMPLEADOS = "dbo.put_Empleados";
        public static string DELETE_EMPLEADOS = "dbo.delete_Empleados";


        public static string GET_PROPIEDADES = "dbo.get_Propiedades";

        // TOKEN
        public static string GET_LOGIN = "dbo.get_Login";

    }
}
