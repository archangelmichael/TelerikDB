using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DataGenerator
{
    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        private static IRandomDataGenerator randomDataGenerator; 
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(Letters[this.GetRandomNumber(0, Letters.Length - 1)]);
            }

            return result.ToString();
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return GetRandomString(this.GetRandomNumber(min, max));
        }

        public DateTime GetRandomDateSinceNow(int days)
        {
            DateTime start = DateTime.Now;
            int miliseconds = days * 24 * 60 * 60;
            return start.AddSeconds(this.GetRandomNumber(0, days));
        }
    }
}
