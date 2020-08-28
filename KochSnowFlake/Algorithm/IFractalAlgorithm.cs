using System.Windows.Media;

namespace KochSnowFlake.Algorithm
{
    public interface IFractalAlgorithm
    {
        void DoRecursive(PointCollection outputPointCollection, int iteration, PointCollection inputPointCollection);
    }
}