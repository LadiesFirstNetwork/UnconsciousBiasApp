using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiasApp.Test
{
    // Test storage methods
    [TestClass]
    public class StorageTest
    {

        [TestMethod]
        public void ThisShouldPass()
        {
            // Arrange


            // Act


            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task ThisShouldFail()
        {
            // Arrange
            

            // Act
            await Task.Run(() => { throw new Exception("boom"); });


            // Assert

        }
    }
}