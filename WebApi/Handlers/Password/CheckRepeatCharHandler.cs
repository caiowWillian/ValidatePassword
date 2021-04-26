using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckRepeatCharHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.VerifyRepeatChar()) return false;

            return CheckNext(userPassword);
        }
    }
}