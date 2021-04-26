using WebApi.Model;

namespace WebApi.Middleware.Password
{
    public class CheckSpecialCharHandler : AHandler<UserPassword>
    {
        public override bool Check(UserPassword userPassword)
        {
            if(userPassword.VerifySpecialChar()) return CheckNext(userPassword);

            return false;
        }
    }
}