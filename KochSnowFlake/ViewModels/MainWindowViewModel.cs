using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using KochSnowFlake.Algorithm;
using KochSnowFlake.Commands;

namespace KochSnowFlake.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const int CanvasWidthHalf = 400;
        private const int LineLength = 300;
        private const int StartX = 250;
        private const int StartY = 310;

        private readonly IFractalAlgorithm _algorithm;

        private int _iterations;
        private int _pointCount;
        private PointCollection _points;

        public MainWindowViewModel()
        {
            InitPointCollection();

            //Todo: Get from dependency injection
            _algorithm = new KochSnowFlakeAlgorithm();

            StartIteration = new DelegateCommand(ExecuteIteration, o => true);
        }

        public PointCollection Points
        {
            get => _points;
            set
            {
                SetProperty(ref _points, value);
                PointCount = _points.Count;
            }
        }

        public ICommand StartIteration { get; set; }

        public int Iterations
        {
            get => _iterations;
            set => SetProperty(ref _iterations, value);
        }

        public int PointCount
        {
            get => _pointCount;
            set => SetProperty(ref _pointCount, value);
        }

        private void InitPointCollection()
        {
            Points = new PointCollection
            {
                new Point(StartX, StartY),
                new Point(StartX + LineLength, StartY),
                new Point(CanvasWidthHalf, StartY - Math.Sqrt(3) * LineLength / 2),
                new Point(StartX, StartY)
            };
        }

        private void ExecuteIteration(object obj)
        {
            InitPointCollection();

            var outputPointCollection = new PointCollection {Points[0]};

            _algorithm.DoRecursive(outputPointCollection, Iterations, Points);

            Points = new PointCollection(outputPointCollection);
        }
    }
}