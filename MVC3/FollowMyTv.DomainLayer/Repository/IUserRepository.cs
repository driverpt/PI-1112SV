namespace FollowMyTv.DomainLayer.Repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        bool TryAuthenticate(string username, string password, out User user);
        User GetByUsername(string username);
        bool CreateUser(string username, string password, string email, Role role);
        bool ActivateUser(string username);
        bool SetUserRole(string username, Role role);
        bool ChangePassword(string username, string newPassword);
    }
}