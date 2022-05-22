using NUnit.Framework;
using RocketLand;

namespace RocketLandTest
{
    public class LandingAreaTest
    {
        private LandingArea landingArea;

        [OneTimeSetUp]
        public void Setup()
        {
            landingArea = new LandingArea();
        }

        [Test, Order(1)]
        public void CanLandIncorrectPositionTest()
        {
            string response = landingArea.CanLand(4, 5);
            Assert.AreEqual(response, "out of platform");
        }

        [Test, Order(2)]
        public void CanLandCorrectPositionTest()
        {
            string response = landingArea.CanLand(5, 5);
            Assert.AreEqual(response, "ok for landing");
        }

        [Test, Order(3)]
        public void CanLandPreviousCheckedPositionTest()
        {
            string response = landingArea.CanLand(5, 5);
            Assert.AreEqual(response, "clash");
        }

        [Test, Order(4)]
        public void CanLandClosePreviousCheckedPositionTest()
        {
            string response = landingArea.CanLand(6, 6);
            Assert.AreEqual(response, "clash");
        }

        [Test, Order(5)]
        public void CanLandCorrectPosition2Test()
        {
            string response = landingArea.CanLand(14, 14);
            Assert.AreEqual(response, "ok for landing");
        }
    }
}