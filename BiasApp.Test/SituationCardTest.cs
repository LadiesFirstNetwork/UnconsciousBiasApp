using BiasApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BiasApp.Test
{
    [TestClass]
    public class SituationCardTest
    {
        private string id = "";
        private string cat = "";
        private string scene = "";
        private string bias = "";
        private string handling = "";
        private string input = "";

        [TestMethod]
        public void Constructor_WithValidInput_ShouldCreateObject()
        {
            // TC1

            // Arrange
            id = "8;";
            cat = "Category;";
            scene = "Scene;";
            bias = "Biases;";
            handling = "Handling";
            input = id += cat += scene += bias += handling;
            SituationCard expected = new SituationCard("8;Category;Scene;Biases;Handling");

            // Act
            SituationCard sut = new SituationCard(input);

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(object));
            Assert.AreEqual(expected.ID, sut.ID);
            Assert.AreEqual(expected.Category, sut.Category);
            Assert.AreEqual(expected.Scene, sut.Scene);
            Assert.AreEqual(expected.Biases, sut.Biases);
            Assert.AreEqual(expected.Handling, sut.Handling);
        }

        [TestMethod]
        public void Constructor_WithValidInputContainsExtraSpaces_ShouldCreateObject()
        {
            // TC2
            
            // Arrange
            id = "5;";
            cat = " Text A ;";
            scene = " Text B ;";
            bias = " Text C ;";
            handling = " Text D . ";
            input = id += cat += scene += bias += handling;
            SituationCard expected = new SituationCard("5; Text A ; Text B ; Text C ; Text D .");

            // Act
            SituationCard sut = new SituationCard(input);

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(object));
            Assert.AreEqual(expected.ID, sut.ID);
            Assert.AreEqual(expected.Category, sut.Category);
            Assert.AreEqual(expected.Scene, sut.Scene);
            Assert.AreEqual(expected.Biases, sut.Biases);
            Assert.AreEqual(expected.Handling, sut.Handling);
            Assert.AreEqual("Text D .", sut.Handling); // Check at trim() er blevet udført korrekt.
        }

        [TestMethod]
        public void Constructor_WhenIdContainsLetter_ShouldThrowNullReferenceCausedByFormatException()
        {
            // TC3

            // Arrange
            id = "a . 10;";
            cat = " Throws;";
            scene = " Null;";
            bias = " Reference;";
            handling = " Exception";
            input = id += cat += scene += bias += handling;

            // Act & Assert
            var sut = Assert.ThrowsException<NullReferenceException>(() => new SituationCard(input));
            
            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }

        [TestMethod]
        public void Constructor_WhenMissingASemicolon_ShouldThrowNullReferenceCausedByIndexOutOfRangeException()
        {
            // TC4

            // Arrange
            id = "2;";
            cat = " Index;";
            scene = " Out";
            bias = "Of;";
            handling = "Range.";
            input = id += cat += scene += bias += handling;
            
            // Act & Assert
            var sut = Assert.ThrowsException<NullReferenceException>(() => new SituationCard(input));

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }

        [TestMethod]
        public void Constructor_WhenMissingAllSemicolon_ShouldThrowNullReferenceCausedByFormatException()
        {
            // TC5

            // Arrange
            id = "1, ";
            cat = "Format ";
            scene = " Exception, ";
            bias = "No ";
            handling = "Creation ";
            input = id += cat += scene += bias += handling;

            // Act & Assert
            var sut = Assert.ThrowsException<NullReferenceException>(() => new SituationCard(input));

            // Assert
            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(NullReferenceException));
        }
    }
}
