using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using KochSnowFlake.Commands;

namespace KochSnowFlake.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const int CanvasWidthHalf = 400;
        private const int LineLength = 300;
        private const int StartX = 250;
        private const int StartY = 310;

        private int _iterations;
        private PointCollection _points;

        public MainWindowViewModel()
        {
            InitPointCollection();

            StartIteration = new DelegateCommand(ExecuteIteration, o => true);
        }

        public PointCollection Points
        {
            get => _points;
            set => SetProperty(ref _points, value);
        }

        public ICommand StartIteration { get; set; }

        public int Iterations
        {
            get => _iterations;
            set => SetProperty(ref _iterations, value);
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

            var pointCollection = new PointCollection();

            DoRecursive(pointCollection, Iterations, Points[0].X, Points[0].Y, Points[1].X, Points[1].Y);

            DoRecursive(pointCollection, Iterations, Points[1].X, Points[1].Y, Points[2].X, Points[2].Y);

            DoRecursive(pointCollection, Iterations, Points[2].X, Points[2].Y, Points[3].X, Points[3].Y);

            Points = new PointCollection(pointCollection);
        }


        private static void DoRecursive(PointCollection pointCollection, int iteration,
            double x12,
            double y12,
            double x22,
            double y22)
        {
            var dx = (x22 - x12) / 3;
            var dy = (y22 - y12) / 3;
            var xx = x12 + 3 * dx / 2 - dy * Math.Sin(Math.PI / 3);
            var yy = y12 + 3 * dy / 2 + dx * Math.Sin(Math.PI / 3);

            if (iteration <= 0)
            {
                pointCollection.Add(new Point(x12, y12));
                pointCollection.Add(new Point(x22, y22));
            }
            else
            {
                DoRecursive(pointCollection, iteration - 1, x12, y12, x12 + dx, y12 + dy);
                DoRecursive(pointCollection, iteration - 1, x12 + dx, y12 + dy, xx, yy);
                DoRecursive(pointCollection, iteration - 1, xx, yy, x22 - dx, y22 - dy);
                DoRecursive(pointCollection, iteration - 1, x22 - dx, y22 - dy, x22, y22);
            }
        }
    }
}