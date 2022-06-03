using Assignment2.Model;

namespace Assignment2.Repository
{


    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user);

    }
}
