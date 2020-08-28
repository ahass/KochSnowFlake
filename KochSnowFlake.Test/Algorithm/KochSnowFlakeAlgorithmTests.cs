using System;
using System.Windows;
using System.Windows.Media;
using KochSnowFlake.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KochSnowFlake.Test.Algorithm
{
    [TestClass]
    public class KochSnowFlakeAlgorithmTests
    {
        private const int CanvasWidthHalf = 400;
        private const int LineLength = 300;
        private const int StartX = 250;
        private const int StartY = 310;

        [TestMethod]
        public void DoRecursive_KochSnowFlakeAlgorithm_InputOutput_I1()
        {
            // Arrange
            var kochSnowFlakeAlgorithm = new KochSnowFlakeAlgorithm();
            var inputPointCollection = new PointCollection
            {
                new Point(StartX, StartY),
                new Point(StartX + LineLength, StartY),
                new Point(CanvasWidthHalf, StartY - Math.Sqrt(3) * LineLength / 2),
                new Point(StartX, StartY)
            };

            var iteration = 1;

            var outputPointCollection = new PointCollection {inputPointCollection[0]};

            // Act
            kochSnowFlakeAlgorithm.DoRecursive(
                outputPointCollection,
                iteration,
                inputPointCollection);

            // Assert
            Assert.AreEqual(13, outputPointCollection.Count);
        }

        //Todo: Test function parameter checks
    }
}