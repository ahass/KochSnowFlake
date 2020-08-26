using KochSnowFlake.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KochSnowFlake.Test.ViewModels
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void TestInitialState()
        {
            // Arrange
            var viewModel = new MainWindowViewModel();

            // Assert
            Assert.AreEqual(4, viewModel.Points.Count);
            Assert.AreEqual(0, viewModel.Iterations);
            Assert.AreEqual(true, viewModel.StartIteration.CanExecute(null));
        }

        [TestMethod]
        public void TestIteration_1()
        {
            // Arrange
            var viewModel = new MainWindowViewModel {Iterations = 1};


            if (viewModel.StartIteration.CanExecute(null))
                viewModel.StartIteration.Execute(null);
            else
                Assert.Fail("Start Iteration not possible");


            // Assert
            Assert.AreEqual(24, viewModel.Points.Count); //24 Points = 12 Lines
            Assert.AreEqual(1, viewModel.Iterations);
        }

        [TestMethod]
        public void TestIteration_2()
        {
            // Arrange
            var viewModel = new MainWindowViewModel {Iterations = 2};


            if (viewModel.StartIteration.CanExecute(null))
                viewModel.StartIteration.Execute(null);
            else
                Assert.Fail("Start Iteration not possible");


            // Assert
            Assert.AreEqual(96, viewModel.Points.Count); //24 Points = 12 Lines
            Assert.AreEqual(2, viewModel.Iterations);
        }
    }
}