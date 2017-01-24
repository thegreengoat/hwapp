using System;
using Xunit;
using HelloWorld;

namespace Tests
{
    public class RandomizerTests
    {
        public class FixedRandomizer : IRandomGenerator {
            public int getRandomInt(int lower, int upper) {
                return lower;
            }
        }

        [Fact]
        public void TestRandomizer() {
            // TODO : Implement Chi-square test for random distribution.
            IRandomGenerator rnd = new DefaultRandomizer();
            var lower = 1; var upper = 10;
            for(int n = 0; n < 1000; n++) {
                var r = rnd.getRandomInt(lower, upper);
                Assert.True(r >= lower && r <= upper);
            }
        }

        [Fact]
        public void TestWelcomeMessage() {
            var r = new FixedRandomizer();
            var a = new App(r);
            var s = a.getWelcomeMessage();
            Assert.True(s.Contains("Here is a random integer between 1 and 10 : 1"));
        }
    }
}
