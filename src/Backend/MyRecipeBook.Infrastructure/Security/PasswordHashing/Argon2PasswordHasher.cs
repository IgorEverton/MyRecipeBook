using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;
using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALLELISM = 1;
    private const int ITERATIONS = 2;
    private const int MemorySize = 20 * 1024;
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;

    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        var hashAlgorithm = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            Iterations = ITERATIONS,
            MemorySize = MemorySize,
            Salt = salt
        };
        var hash = hashAlgorithm.GetBytes(HASH_SIZE);

        var combinedBytes = new byte[SALT_SIZE + HASH_SIZE];

        salt.CopyTo(combinedBytes, 0);
        hash.CopyTo(combinedBytes, SALT_SIZE);

        return Convert.ToBase64String(combinedBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}
