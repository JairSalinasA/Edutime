namespace EduTime.DataAccess.Entities
{
    public class Usuario
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleID { get; set; }
        public string ActivationKey { get; set; }
    }
}
