using WormsDeathmatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace Tests
{
    
    
    /// <summary>
    ///This is a test class for UtilityTest and is intended
    ///to contain all UtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilityTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// A test for Distance method
        /// </summary>
        [TestMethod()]
        public void DistanceTest()
        {
            Assert.AreEqual(true, Utility.Distance(new Vector2(0, 0), new Vector2(0, 0)) == 0);
            Assert.AreEqual(true, Utility.Distance(new Vector2(0, 1), new Vector2(0, 0)) == 1);
            Assert.AreEqual(true, Utility.Distance(new Vector2(3, 4), new Vector2(0, 0)) == 5);
            Assert.AreEqual(true, Utility.Distance(new Vector2(16, 0), new Vector2(12, 3)) == 5);

            float actual = Utility.Distance(new Vector2(1, 1), new Vector2(0, 0));
            Assert.AreEqual(true, actual > 1.40f && actual < 1.42f);

        }


        /// <summary>
        ///A test for CircleIntersectsRectangle
        ///</summary>
        [TestMethod()]
        public void CircleIntersectsRectangleTest()
        {

            Worm Worm = new Worm();

            Worm.Position = new Vector2(0, 0);

            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(0, 0), 1, Worm));
            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(0, 0), 0.0001f, Worm));
            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(0, 0), 0, Worm));

            // Worm size - (0, 0)
            // Checking distance from circle to point

            // 0 radius should return false
            Assert.AreEqual(false, Utility.CircleIntersectsRectangle(new Vector2(-1, 0), 0, Worm));
            Assert.AreEqual(false, Utility.CircleIntersectsRectangle(new Vector2(1, 0), 0, Worm));

            // test based on circle radius
            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(1, 1), 1, Worm));
            Assert.AreEqual(false, Utility.CircleIntersectsRectangle(new Vector2(0, 2), 1, Worm));
            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(0, 2), 2, Worm));

            // test based on worm radius
            Worm.GroundCollisionSize = new Vector2(10, 10); // rect (-5. -5, 10, 10)

            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(6, 0), 1, Worm));
            Assert.AreEqual(true, Utility.CircleIntersectsRectangle(new Vector2(0, 6), 1, Worm));

            Assert.AreEqual(false, Utility.CircleIntersectsRectangle(new Vector2(6, 0), 0.5f, Worm));
            Assert.AreEqual(false, Utility.CircleIntersectsRectangle(new Vector2(0, 6), 0.5f, Worm));
        }
    }
}
