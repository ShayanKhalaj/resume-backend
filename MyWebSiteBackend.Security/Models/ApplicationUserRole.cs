namespace MyWebSiteBackend.Security.Models
{
    public class ApplicationUserRole
    {
        public int Id { get; set; }
        public int FKUserID { get; set; }
        public ApplicationUser User { get; set; }
        public int FKRoleID { get; set; }
        public ApplicationRole Role { get; set; }
    }
}