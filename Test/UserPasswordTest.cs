using Xunit;
using WebApi.Model;
namespace Test
{
    public class UserPasswordTest
    {
        [Theory()]
        [InlineData("teste ")]
        public void NegativeContainsWhiteSpaceTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).ContainsWhiteSpace(),true);
        }
        
        [Theory()]
        [InlineData("teste")]
        public void ContainsWhiteSpaceTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).ContainsWhiteSpace(),false);
        }

        [Theory()]
        [InlineData("teste1234")]
        [InlineData("teste12345")]
        public void VerifyMinimumLengthTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyMinimumLength(),true);
        }

        [Theory()]
        [InlineData("teste123")]
        public void NegativeVerifyMinimumLengthTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyMinimumLength(),false);
        }

        [Theory()]
        [InlineData("AAAAAAAAAAA")]
        public void NegativeVerifyLowerCaseTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyLowerCase(),false);
        }
            
        [Theory()]
        [InlineData("AAAAAaAAAAA")]
        [InlineData("aaaaaaaaa")]
        public void VerifyLowerCaseTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyLowerCase(),true);
        }

        [Theory()]
        [InlineData("AAAAAaAAAAA")]
        [InlineData("aaaAaaaaa")]
        public void VerifyUpperCaseTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyUpperCase(),true);
        }

        [Theory()]
        [InlineData("aaaaaaaaaaa")]
        public void NegativeVerifyUpperCaseTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyUpperCase(),false);
        }

        [Theory()]
        [InlineData("@")]
        [InlineData("!")]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("%")]
        [InlineData("^")]
        [InlineData("&")]
        [InlineData("*")]
        [InlineData("(")]
        [InlineData(")")]
        [InlineData("-")]
        [InlineData("+")]
        public void VerifySpecialCharTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifySpecialChar(),true);
        }

        [Theory()]
        [InlineData("abc")]
        public void VerifyRepeatCharTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyRepeatChar(),false);
        }

        [Theory()]
        [InlineData("aaaa")]
        public void NegativeVerifyRepeatCharTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).VerifyRepeatChar(),true);
        }

        [Theory()]
        [InlineData("AbTp9!fok")]
        public void IsValidTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).IsValid(),true);
        }

        [Theory()]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        public void IsNotValidTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).IsValid(),false);
        }

        [Theory()]
        [InlineData("teste1")]
        public void HasADigitTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).HasDigit(),true);
        }

        [Theory()]
        [InlineData("teste")]
        public void NegativeHasADigitTest(string pass)
        {
            Assert.Equal(new UserPassword(pass).HasDigit(),false);
        }
    }


}
