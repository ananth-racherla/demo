using NUnit.Framework;

/// <summary>
/// NUnit Test Cases
/// </summary>
namespace HelloTest {

    [TestFixture]
    public class NUnitTest {

        [Test]
        public void TestAddition()
        {
            int expectedResult = 1 + 1;
            Assert.That(expectedResult, Is.EqualTo(2));
        }


        [Test]
        public void StringIsEmpty()
        {
            string empty = "";
            Assert.IsTrue(empty == string.Empty);
        }


        [Test]
        public void NameIsAnanth()
        {
            string name = "Ananth";
            Assert.IsTrue(name == "Ananth", "Expected to see Ananth. However name param contained: " + name);
        }
    }
}
