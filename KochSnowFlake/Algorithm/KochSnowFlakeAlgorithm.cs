using System;
using System.Windows;
using System.Windows.Media;

namespace KochSnowFlake.Algorithm
{
    public class KochSnowFlakeAlgorithm : IFractalAlgorithm
    {
        public void DoRecursive(PointCollection outputPointCollection, int iteration,
            PointCollection inputPointCollection)
        {
            if (outputPointCollection.Count < 1)
                throw new ArgumentOutOfRangeException(nameof(outputPointCollection) + " must contain start point.");

            if (iteration < 0) throw new ArgumentOutOfRangeException(nameof(iteration) + "must be positive.");

            if (inputPointCollection.Count < 2)
                throw new ArgumentOutOfRangeException(nameof(inputPointCollection) +
                                                      " must contains at least two points.");

            for (var run = 0; run < inputPointCollection.Count - 1; run++)
            {
                var p1 = inputPointCollection[run];
                var p2 = inputPointCollection[run + 1];

                var dx = (p2.X - p1.X) / 3;
                var dy = (p2.Y - p1.Y) / 3;
                var xx = p1.X + 3 * dx / 2 - dy * Math.Sin(Math.PI / 3);
                var yy = p1.Y + 3 * dy / 2 + dx * Math.Sin(Math.PI / 3);

                if (iteration <= 0)
                {
                    outputPointCollection.Add(new Point(p2.X, p2.Y));
                }
                else
                {
                    var segment1P1 = new Point(p1.X, p1.Y);
                    var segment1P2 = new Point(p1.X + dx, p1.Y + dy);
                    var segment2P1 = new Point(p1.X + dx, p1.Y + dy);
                    var segment2P2 = new Point(xx, yy);
                    var segment3P1 = new Point(xx, yy);
                    var segment3P2 = new Point(p2.X - dx, p2.Y - dy);
                    var segment4P1 = new Point(p2.X - dx, p2.Y - dy);
                    var segment4P2 = new Point(p2.X, p2.Y);

                    DoRecursive(outputPointCollection, iteration - 1,
                        new PointCollection {segment1P1, segment1P2});
                    DoRecursive(outputPointCollection, iteration - 1,
                        new PointCollection {segment2P1, segment2P2});
                    DoRecursive(outputPointCollection, iteration - 1,
                        new PointCollection {segment3P1, segment3P2});
                    DoRecursive(outputPointCollection, iteration - 1,
                        new PointCollection {segment4P1, segment4P2});
                }
            }
        }
    }
}