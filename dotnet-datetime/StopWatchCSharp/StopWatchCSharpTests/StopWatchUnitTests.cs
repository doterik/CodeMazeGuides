using System.Diagnostics;

namespace StopWatchCSharpTests
{
    [TestClass]
    public class StopWatchUnitTests
    {
        private readonly StopWatchMethods _stopWatchMethods = new();

        [TestMethod]
        public void GivenArraySize_WhenCreateRandomArrayInvoked_VerifyReturnedResults()
        {
            var arraySize = 10;
            var stopWatch = _stopWatchMethods.CreateRandomArray(arraySize);

            Assert.IsInstanceOfType(stopWatch, typeof(Stopwatch));
            Assert.IsInstanceOfType(stopWatch.Elapsed, typeof(TimeSpan));
            Assert.IsInstanceOfType(stopWatch.ElapsedMilliseconds, typeof(long));
            Assert.IsInstanceOfType(stopWatch.ElapsedTicks, typeof(long));
            Assert.IsFalse(stopWatch.IsRunning);
         
            stopWatch.Reset();

            Assert.AreEqual(stopWatch.Elapsed, TimeSpan.Zero);
            stopWatch.Restart();

            Assert.AreEqual(stopWatch.Elapsed.CompareTo(TimeSpan.Zero), 1);
            Assert.IsTrue(stopWatch.IsRunning);

            stopWatch.Stop();

            Assert.IsFalse(stopWatch.IsRunning);
        }
    }
}