using PasswordVerifier;
namespace PasswordVerifyTest
{
    public class UnitTestPassword
    {
        [Theory]
        [InlineData("oausgdsa")]
        [InlineData("appleball123")]
        [InlineData("Abc@123")]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("1234567890")]
        [InlineData("oongaboonga2323")]
        [InlineData("tajikistan66")]
        [InlineData("FRANC")]
        [InlineData("FRANCESCO")]
        [InlineData("APPLE1PAD")]
        [InlineData("   ")]
        [InlineData("astdvhj")]
        [InlineData("a")]
        public void PassswordValidity_InvalidPassword_ThrowsException(string password)
        {
            //arrange
            PasswordVerify passwordVerify = new PasswordVerify();
            //act & assert
            Assert.ThrowsAny<ArgumentException>(() => PasswordVerify.PasswordCheck(password));
        }

        [Theory]
        [InlineData("AppleBall11")]
        [InlineData("Shusank221")]
        [InlineData("Amsterdam220")]
        [InlineData("Football2000")]
        [InlineData("22HowToBasic")]
        [InlineData("12783GGaa")]
        public void PassswordValidity_validPassword_ReturnsTrue(string password)
        {
            //arrange
            PasswordVerify passwordVerify = new PasswordVerify();
            //act 
            var result = PasswordVerify.PasswordCheck(password);
            //assert
            Assert.True(result);
        }
    }
}