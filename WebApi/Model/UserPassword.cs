
using System.Linq;
using WebApi.Interfaces;
using WebApi.Middleware.Password;
namespace WebApi.Model
{
    public class UserPassword : IPassword
    {
        public string Password { get; set; }     

        public UserPassword()
        {
            
        }

        public UserPassword(string password)
        {
            this.Password = password;
        }

        private string[] specialChar = new string[]
        {
            "!",
            "@",
            "#",
            "$",
            "%",
            "^",
            "&",
            "*",
            "(",
            ")",
            "-",
            "+"
        };
        public bool ContainsWhiteSpace()
        {
            return Password.Contains(" ");
        }

        public bool VerifyMinimumLength(){
            return Password.Length >= 9;
        }

        public bool VerifyLowerCase()
        {
            return Password.Any(char.IsLower);
        }

        public bool VerifyUpperCase(){
            return Password.Any(char.IsUpper);
        }

        public bool VerifySpecialChar()
        {
            foreach(var item in specialChar) 
            {
                if(Password.Contains(item)) 
                    return true;
            }
            return false;
        }

        public bool VerifyRepeatChar()
        {
            return Password.GroupBy(x => x).Any(g => g.Count() > 1);
        }

        public bool HasDigit()
        {
            return Password.Any(char.IsDigit);
        }

        public bool IsValid()
        {
            var middleware = new CheckWhiteSpaceHandler();
            middleware.LinkWith(new CheckLengthHandler())
            .LinkWith(new CheckLowerCaseHandler())
            .LinkWith(new CheckupperCaseHandler())
            .LinkWith(new CheckSpecialCharHandler())
            .LinkWith(new CheckRepeatCharHandler())
            .LinkWith(new CheckHasDigitHandler());
            return middleware.Check(this);
        }
    }
}