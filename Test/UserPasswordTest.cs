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
            Assert.True(new UserPassword(pass).ContainsWhiteSpace());
        }
        
        [Theory()]
        [InlineData("teste")]
        public void ContainsWhiteSpaceTest(string pass)
        {
            Assert.False(new UserPassword(pass).ContainsWhiteSpace());
        }

        [Theory()]
        [InlineData("teste1234")]
        [InlineData("teste12345")]
        public void VerifyMinimumLengthTest(string pass)
        {
            Assert.True(new UserPassword(pass).VerifyMinimumLength());
        }

        [Theory()]
        [InlineData("teste123")]
        public void NegativeVerifyMinimumLengthTest(string pass)
        {
            Assert.False(new UserPassword(pass).VerifyMinimumLength());
        }

        [Theory()]
        [InlineData("AAAAAAAAAAA")]
        public void NegativeVerifyLowerCaseTest(string pass)
        {
            Assert.False(new UserPassword(pass).VerifyLowerCase());
        }
            
        [Theory()]
        [InlineData("AAAAAaAAAAA")]
        [InlineData("aaaaaaaaa")]
        public void VerifyLowerCaseTest(string pass)
        {
            Assert.True(new UserPassword(pass).VerifyLowerCase());
        }

        [Theory()]
        [InlineData("AAAAAaAAAAA")]
        [InlineData("aaaAaaaaa")]
        public void VerifyUpperCaseTest(string pass)
        {
            Assert.True(new UserPassword(pass).VerifyUpperCase());
        }

        [Theory()]
        [InlineData("aaaaaaaaaaa")]
        public void NegativeVerifyUpperCaseTest(string pass)
        {
            Assert.False(new UserPassword(pass).VerifyUpperCase());
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
            Assert.True(new UserPassword(pass).VerifySpecialChar());
        }

        [Theory()]
        [InlineData("abc")]
        public void VerifyRepeatCharTest(string pass)
        {
            Assert.False(new UserPassword(pass).VerifyRepeatChar());
        }

        [Theory()]
        [InlineData("aaaa")]
        public void NegativeVerifyRepeatCharTest(string pass)
        {
            Assert.True(new UserPassword(pass).VerifyRepeatChar());
        }

        [Theory()]
        [InlineData("AbTp9!fok")]
        public void IsValidTest(string pass)
        {
            Assert.True(new UserPassword(pass).IsValid());
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
            Assert.False(new UserPassword(pass).IsValid());
        }

        [Theory()]
        [InlineData("teste1")]
        public void HasADigitTest(string pass)
        {
            Assert.True(new UserPassword(pass).HasDigit());
        }

        [Theory()]
        [InlineData("teste")]
        public void NegativeHasADigitTest(string pass)
        {
            Assert.False(new UserPassword(pass).HasDigit());
        }
    }
}
