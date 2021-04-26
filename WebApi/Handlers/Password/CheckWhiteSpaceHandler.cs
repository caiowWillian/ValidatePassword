using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckWhiteSpaceHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.ContainsWhiteSpace()) return false;

            return CheckNext(userPassword);
        }
    }
}