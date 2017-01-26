using System;

namespace HelloWorld
{
    public interface IRandomGenerator {
        int getRandomInt(int lower, int upper);
    }

    public class DefaultRandomizer : IRandomGenerator {
        Random _r = new Random();

        public DefaultRandomizer() {
            _r = new Random();    
        }
        // Generate a random integer between lower and upper.
        public int getRandomInt(int lower, int upper) {    
            return _r.Next(lower, upper+1);
        }
        
    }
}
