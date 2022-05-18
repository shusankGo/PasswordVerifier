using PasswordVerifier;
namespace PasswordVerifyTest
{
    public class UnitTestPassword
    {
        [Theory]
        [InlineData(true, "oausgdsa")]
        [InlineData(true, "Passw0rd")]
        [InlineData(true, "appleball123")]
        [InlineData(true, "AppleBall123")]
        [InlineData(true, "oongaboonga2323")]
        [InlineData(true, "00ngaB00nga")]
        [InlineData(true, "apple123B")]
        [InlineData(true, "tasdvahbjk1223P")]
        [InlineData(true, "tajikistan66")]
        [InlineData(true, "Croatia2000")]
        [InlineData(true, "france")]
        [InlineData(true, "APPLE1PAD")]
        [InlineData(true, "HammerHead1020")]
        [InlineData(true, "MtEverest8848")]
        [InlineData(true, "Quagmire00")]
        [InlineData(true, "HelloWorld")]
        [InlineData(true, "astdvhj")]
        [InlineData(true, "Albanian22")]
        [InlineData(true, "London2020")]
        [InlineData(true, "Qatar2022")]
        public void CheckPasswordVerification(bool expectedResult, string password)
        {
            bool actualResult = false;

            if (PasswordVerify.PasswordCheck(password))
                actualResult = true;

            Assert.Equal(expectedResult, actualResult);

        }
    }
}