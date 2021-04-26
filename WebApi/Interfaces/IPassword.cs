namespace WebApi.Interfaces
{
    public interface IPassword
    {
        bool ContainsWhiteSpace();
        bool VerifyMinimumLength();
        bool VerifyLowerCase();
        bool VerifyUpperCase();
        bool VerifySpecialChar();
        bool VerifyRepeatChar();
        bool IsValid();
        bool HasDigit();
    }
}