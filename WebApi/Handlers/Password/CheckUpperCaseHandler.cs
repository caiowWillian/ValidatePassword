using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckupperCaseHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.VerifyUpperCase()) return CheckNext(userPassword);

            return false;
        }
    }
}