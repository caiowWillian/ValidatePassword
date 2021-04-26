using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckLowerCaseHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {

            if(userPassword.VerifyLowerCase()) return CheckNext(userPassword);

            return false;
        }
    }
}