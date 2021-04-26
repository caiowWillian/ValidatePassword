using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckLengthHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.VerifyMinimumLength()) return CheckNext(userPassword);

            return false;
        }
    }
}