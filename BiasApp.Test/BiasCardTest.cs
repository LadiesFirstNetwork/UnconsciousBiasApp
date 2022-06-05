using BiasApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BiasApp.Test
{
    // Check behaviours of methods
    [TestClass]
    public class BiasCardTest
    {
        private string id = "";
        private string name = "";
        private string description = "";
        private string image = "";
        private string input = "";

        [TestMethod]
        public void Constructor_WithValidInput_ShouldCreateObject()
        {
            // TC 1

            // Arrange
            id = "5;";
            name = "Name;";
            description = "Description;";
            image = "Image";
            input = id + name + description + image;
            BiasCard expected = new BiasCard("5;Name;Description;Image");

            // Act
            BiasCard sut = new BiasCard(input);

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(object));
            Assert.AreEqual(expected.ID, sut.ID);
            Assert.AreEqual(expected.Name, sut.Name);
            Assert.AreEqual(expected.Description, sut.Description);
            Assert.AreEqual(expected.Image, sut.Image);
        }

        [TestMethod]
        public void Constructor_WithValidInputContainsWhiteSpace_ShouldCreateObject()
        {
            // TC 2

            // Arrange
            id = "9 ; ";
            name = " test A; ";
            description = "TestB;";
            image = "  Test C ";
            input = id + name + description + image;
            BiasCard expected = new BiasCard("9 ;  test A; TestB;  Test C ");

            // Act
            BiasCard sut = new BiasCard(input);

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(object));
            Assert.AreEqual(expected.ID, sut.ID);
            Assert.AreEqual(expected.Name, sut.Name);
            Assert.AreEqual(expected.Description, sut.Description);
            Assert.AreEqual(expected.Image, sut.Image);
        }

        [TestMethod]
        public void Constructor_WhenIdContainsLetter_ShouldThrowNullReferenceCausedByFormatException()
        {
            // TC 3
            
            // Arrange
            id = "6 . C;";
            name = " Throws;";
            description = " NullReference;";
            image = " Exception";
            input = id + name + description + image;

            // Act
            var sut = Assert.ThrowsException<NullReferenceException>(() => new BiasCard(input));

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }

        [TestMethod]
        public void Constructor_WhenMissingASemicolon_ShouldThrowNullReferenceCausedByIndexOutOfRangeException()
        {
            // TC 4

            // Arrange
            id = "12;";
            name = " Index";
            description = " OutOf;";
            image = "Range.";
            input = id + name + description + image;

            // Act
            var sut = Assert.ThrowsException<NullReferenceException>(() => new BiasCard(input));

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }

        [TestMethod]
        public void Constructor_WhenMissingAllSemicolon_ShouldThrowNullReferenceCausedByFormatException()
        {
            // TC 5

            // Arrange
            id = " 1,";
            name = " FormatException,";
            description = " No";
            image = " Creation ";
            input = id + name + description + image;

            // Act
            var sut = Assert.ThrowsException<NullReferenceException>(() => new BiasCard(input));

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }
    }
}
