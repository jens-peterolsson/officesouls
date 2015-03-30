using System.Linq;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using AForge;

namespace Itbudet.DecisionTrees
{
    public class Decision
    {
        public int Decide(int hoursOfSleep, int happy)
        {
            // no of hours of sleep / happy / result, tired = 0. otherwise 1
            double[][] learningData =
            {
                new double[] { 6, 0, 1 }, new double[] { 9, 1, 1 }, new double[] { 4, 2, 1 },
                new double[] { 9, 2, 2 }, new double[] { 8, 1, 1 }, new double[] { 7, 0, 0 },
                new double[] { 6, 1, 1 }, new double[] { 5, 1, 0 }, new double[] { 8, 2, 2 },
                new double[] { 5, 2, 1 }, new double[] { 4, 1, 0 }, new double[] { 6, 0, 0 }
            };

            // Creates a matrix from the entire source data table
            double[,] table = learningData.ToMatrix();

            var inputs = learningData.Select(i => new [] {i[0], i[1]}).ToArray();
            // first array = no of hours sleep, second array = happy
            // Get only the output labels (last column)
            var outputs = learningData.Select(i => (int) i[2]).ToArray();

            // Specify the input variables
            var rangeSleep = new DoubleRange(0, 20);
            var rangeHappy = new DoubleRange(0, 2);

            DecisionVariable[] variables = 
            {
                DecisionVariable.Continuous("x", rangeSleep),
                DecisionVariable.Continuous("y", rangeHappy)
            };

            var tree = new DecisionTree(variables, 3);

            // Create the C4.5 learning algorithm
            var c45 = new C45Learning(tree);

            // Learn the decision tree using C4.5
            double error = c45.Run(inputs, outputs);

            //TODO: create the winforms project to see spread?
            // Get the ranges for each variable (X and Y)
            //var ranges = table.Range(0);

            //// Generate a Cartesian coordinate system
            //double[][] map = Matrix.CartesianProduct(
            //    Matrix.Interval(ranges[0], 0.05),
            //    Matrix.Interval(ranges[1], 0.05));

            // Classify each point in the Cartesian coordinate system
            //double[] result = map.Apply(tree.Compute).ToDouble();
            //double[,] surface = map.ToMatrix().InsertColumn(result);

            var result = tree.Compute(new int[] {hoursOfSleep, happy});
            return result;
        }
    }
}
