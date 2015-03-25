using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using AForge;

namespace Itbudet.DecisionTrees
{
    public class Decision
    {
        public int Decide(int happy, int hoursOfSleep)
        {
            // Creates a matrix from the entire source data table
            double[,] table = null;// = (dgvLearningSource.DataSource as DataTable).ToMatrix(out columnNames);

            // Get only the input vector values (first two columns)
            double[][] inputs = null;// = table.GetColumns(0, 1).ToArray();

            // Get only the output labels (last column)
            int[] outputs = null;// = table.GetColumn(2).ToInt32();

            // Specify the input variables
            var rangeSleep = new DoubleRange(1, 10);
            var rangeHappy = new DoubleRange(0, 2);

            DecisionVariable[] variables = 
            {
                DecisionVariable.Continuous("x", rangeSleep),
                DecisionVariable.Continuous("y", rangeHappy)
            };

            var tree = new DecisionTree(variables, 2);

            // Create the C4.5 learning algorithm
            var c45 = new C45Learning(tree);

            // Learn the decision tree using C4.5
            double error = c45.Run(inputs, outputs);

            // Get the ranges for each variable (X and Y)
            DoubleRange[] ranges = Matrix.Range(table, 0);

            // Generate a Cartesian coordinate system
            double[][] map = Matrix.CartesianProduct(
                Matrix.Interval(ranges[0], 0.05),
                Matrix.Interval(ranges[1], 0.05));

            // Classify each point in the Cartesian coordinate system
            double[] result = map.Apply(tree.Compute).ToDouble();
            //double[,] surface = map.ToMatrix().InsertColumn(result);

            //var z = tree.Compute(new int[] {7, 1});
            return 0;
        }
    }
}
