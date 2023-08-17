using System.Diagnostics;
using System.Text;

namespace pwgen {

    public static class Utils {

        public static List<string> GeneratePasswords(bool alpha, bool ALPHA, bool numbers, bool special, int count, int length) {
            if (Debugger.IsAttached) {
                Console.WriteLine($"Generating {count} passwords of {length} characters");
            }

            var sb = new StringBuilder();

            if (alpha) {
                sb.Append(GetAsciiChars(97, 122));
            }
            if (ALPHA) {
                sb.Append(GetAsciiChars(65, 90));
            }
            if (numbers) {
                sb.Append(GetAsciiChars(48, 57));
            }
            if (special) {
                // ASCII values 33..47, 58..64, 91..96, 123..126
                sb.Append(GetAsciiChars(33, 47));
                sb.Append(GetAsciiChars(58, 64));
                sb.Append(GetAsciiChars(91, 96));
                sb.Append(GetAsciiChars(123, 126));
            }

            var alphabet = sb.ToString();

            if (Debugger.IsAttached) {
                Console.WriteLine($"The alphabet is: {alphabet}");
            }

            var passwords = new List<string>();

            for (int i = 0; i < count; i++) {
                passwords.Add(GeneratePassword(alphabet, length));
            }

            return passwords;
        }

        public static string GeneratePassword(string alphabet, int length) {
            var password = new StringBuilder();
            var rand = new Random((int)DateTimeOffset.UtcNow.Ticks);

            for (int i = 0; i < length; i++) {
                int index = rand.Next(0, alphabet.Length);
                var ch = alphabet[index];
                password.Append(ch);
            }

            return password.ToString();
        }

        public static string GetAsciiChars(int start, int end) {
            if (end < start) {
                throw new ArgumentException($"You can't have {end} before {start}");
            }

            var result = string.Empty;

            for (int i = start; i <= end; i++) {
                result += (char)i;
            }

            return result;
        }
    }
}