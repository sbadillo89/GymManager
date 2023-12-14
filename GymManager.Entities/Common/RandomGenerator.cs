
namespace GymManager.Entities.Common
{
    public static class RandomGenerator
    {
        public static string GenerateRandomString(int size)
        {
            var random = new Random();
            var chars = "QWERTYUIOPñLKJHGFDSAZXCVBNMqwertyuiopasdfghjklñmnbvcxz!#$%&/()=?¡_-*<>";

            return new string(Enumerable.Repeat(chars, size).
                                Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}