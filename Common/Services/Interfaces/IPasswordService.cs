namespace Common.Services
{
    public interface IPasswordService
    {
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}