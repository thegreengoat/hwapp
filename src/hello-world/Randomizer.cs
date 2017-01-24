using System;

namespace HelloWorld
{
    public interface IRandomGenerator {
        int getRandomInt(int lower, int upper);
    }

    public class DefaultRandomizer : IRandomGenerator {
        
        // Generate a random integer between lower and upper.
        public int getRandomInt(int lower, int upper) {    
            return new Random().Next(lower, upper+1);
        }
        
    }
}
