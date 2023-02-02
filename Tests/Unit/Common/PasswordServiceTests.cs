using Common.Services;
using Tests.Helpers;

namespace Tests.Unit.Common
{
    public class PasswordServiceTests
    {
        private const string _password = "password";
        private IPasswordService _service;
        private readonly byte[] OneByteArray = new byte[1];

        public PasswordServiceTests() => _service = new PasswordService();

        [Theory]
        [InlineData("")]
        [InlineData("            ")]
        public void CreatePasswordHash_ThrowsArgumentException_WhenPassword_IsNullOrWhiteSpace(string password) => Assert.Throws<ArgumentException>(() => _service.CreatePasswordHash(password, out var hash, out var salt));

        [Fact]
        public void CreatePasswordHash_ThrowsArgumentNullException_WhenPassword_IsNull() => Assert.Throws<ArgumentNullException>(() => _service.CreatePasswordHash(null, out var hash, out var salt));

        [Fact]
        public void CreatePasswordHash_Success()
        {
            _service.CreatePasswordHash(_password, out var hash, out var salt);
            
            Assert.True(salt.Length > 0);
            Assert.True(hash.Length > 0);
        }
        
        [Fact]
        public void VerifyPasswordHash_Success()
        {
            string password = "dimi";
            var passwordHashed = @"39C0880732E69C81BB394A470352AD8AAFB77B37B6288EB2CB5BE0FE7DF319174A561C1D4C95DA3A252BAE2A15201CA340CD0EEAEEA3DB4FDD2578CD45D25EEB";
            var passwordSalt =
                @"FB076227EE71008B50D4BDE28B7720A575D99FABCD0FD4B5A847F0D65FBC374DD9C9CBF0E8A746F4FBC14A91221946CB2279C4F8C0EAB88DB573C43840AEF6C6977946A1E3AB95F1488173BA6061D749B237A556BF3553F2B029D58DA3C37F0717CB82FD606E5FB674E252F4E8193CDF98C26421CCB0EF106DB17079F2DC876F";

            var hashedPassword = HelperMethods.ConvertHexStringToByteArray(passwordHashed);
            var hashedSalt = HelperMethods.ConvertHexStringToByteArray(passwordSalt);
            var result = _service.VerifyPasswordHash(password, hashedPassword, hashedSalt);
            
            Assert.True(result);
        }
               
        [Fact]
        public  void VerifyPasswordHash_ThrowsArgumentNullException_WhenPassword_IsNull() => Assert.Throws<ArgumentNullException>(() => _service.VerifyPasswordHash(null, OneByteArray, OneByteArray));

        [Theory]
        [InlineData("")]
        [InlineData("            ")]
        public void VerifyPasswordHash_ThrowsArgumentException_WhenPassword_IsNullOrWhiteSpace(string password) => Assert.Throws<ArgumentException>(() => _service.VerifyPasswordHash(password, OneByteArray,OneByteArray));

        [Fact]
        public void VerifyPasswordHash_ThrowsArgumentException_WhenPasswordHash_IsInvalid() => Assert.Throws<ArgumentException>(() => _service.VerifyPasswordHash(_password, OneByteArray, OneByteArray));

        [Fact]
        public void VerifyPasswordHash_ThrowsArgumentException_WhenPasswordSalt_IsInvalid() => Assert.Throws<ArgumentException>(() => _service.VerifyPasswordHash(_password, new byte[64], OneByteArray));
    }
}