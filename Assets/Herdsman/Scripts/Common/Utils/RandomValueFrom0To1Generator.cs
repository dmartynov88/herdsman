using System;

namespace Common.Utils
{
    public static class RandomValueFrom0To1Generator
    {
        private static Random random;

        static RandomValueFrom0To1Generator()
        {
            random = new Random();
        }
        
        public static float Get()
        {
            return (float)random.NextDouble();
        }
    }
}