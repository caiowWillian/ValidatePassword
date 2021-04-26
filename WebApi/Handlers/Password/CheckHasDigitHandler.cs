using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckHasDigitHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.HasDigit()) return CheckNext(userPassword);

            return false;
        }
    }
}