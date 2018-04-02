namespace RandomGeneration
{
    using System;
    using System.Text;

    public class RandomValueGenerator
    {
        private static RandomValueGenerator instance;
        private readonly string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly Random random;

        private RandomValueGenerator()
        {
            this.random = new Random();
        }

        public static RandomValueGenerator Instance()
        {
            if (instance == null)
            {
                instance = new RandomValueGenerator();
            }

            return instance;
        }

        public string GenerateString(int length, string charsAllowed = null)
        {
            if (length <= 0)
            {
                throw new InvalidOperationException("length cannot be zero or negative.");
            }

            StringBuilder builder = new StringBuilder(length);
            string source = charsAllowed == null ? this.chars : charsAllowed;
            while (length > 0)
            {
                int position = this.random.Next(0, source.Length);
                builder.Append(source[position]);
                length--;
            }

            return builder.ToString();
        }

        public int GenerateInteger(int minValue, int maxValue)
        {
            return this.random.Next(minValue, maxValue + 1);
        }
    }
}
