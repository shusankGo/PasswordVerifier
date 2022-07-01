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
            //act & assert
            Assert.ThrowsAny<AggregateException>(() => PasswordVerify.PasswordCheck(password));
        }

        [Theory]
        [InlineData("AppleBall11")]
        [InlineData("Shusank221")]
        [InlineData("Amsterdam420")]
        [InlineData("Football2000")]
        [InlineData("22HowToBasic")]
        [InlineData("12783GGaa")]
        [InlineData("1234567ABcd")]
        [InlineData("kickBall442200")]
        [InlineData("HelloWorld2022")]
        public void PassswordValidity_ValidPassword_ReturnsTrue(string password)
        {
            //act 
            var result = PasswordVerify.PasswordCheck(password);
            //assert
            Assert.True(result); 
        }
    }
}