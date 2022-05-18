using PasswordVerifier;
namespace PasswordVerifyTest
{
    public class UnitTestPassword
    {
        [Theory]
        [InlineData(false, "oausgdsa")]
        [InlineData(true, "Passw0rd")]
        [InlineData(false, "appleball123")]
        [InlineData(true, "AppleBall123")]
        [InlineData(false, "oongaboonga2323")]
        [InlineData(true, "00ngaB00nga")]
        [InlineData(true, "apple123B")]
        [InlineData(true, "tasdvahbjk1223P")]
        [InlineData(false, "tajikistan66")]
        [InlineData(true, "Croatia2000")]
        [InlineData(false, "france")]
        [InlineData(false, "APPLE1PAD")]
        [InlineData(true, "HammerHead1020")]
        [InlineData(true, "MtEverest8848")]
        [InlineData(true, "Quagmire00")]
        [InlineData(false, "HelloWorld")]
        [InlineData(false, "astdvhj")]
        [InlineData(true, "Albanian22")]
        [InlineData(true, "London2020")]
        [InlineData(true, "Qatar2022")]
        public void CheckPasswordVerification(bool expectedResult, string password)
        {
            bool actualResult = PasswordVerify.PasswordCheck(password);

            Assert.Equal(expectedResult, actualResult);

        }
    }
}