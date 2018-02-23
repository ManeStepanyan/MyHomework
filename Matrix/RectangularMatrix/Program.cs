using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        { double[,]arr = new double[3,3] { { 1,2,3 }, { 0,1,4},{ 5,6,0 } };
            Matrix m = new Matrix(arr);
              Matrix m1 = new Matrix(3, 3);
             double[,] arr1 = new double[3, 3] { { 0, 1 ,1}, { 2, -1 ,1}, {1, -1, -1} };
              m1.data = arr1;
            //  Matrix temp = m + m1;
            //  temp.Print();
            // Matrix forInverse = new Matrix(3, 3);
            // Random r = new Random(4);
            //   for(int i=0; i<3; i++)
            //   {
            //  for(int j=0; j<3; j++)
            //   {
            //       forInverse[i, j] = r.Next(2, 5);
            // }
            //  } forInverse.Print();
            //forInverse=forInverse.Inverse();

            //  forInverse.Print();
            // bool b=  forInverse.IsOrthogonal();
            // Console.WriteLine(b);
             Vector v = new Vector(1d, 2d, 6d);

            //     Matrix.RotateVectorAboutY((Math.PI)/2d, v);
            //    Matrix.ScalingByKthCoordinateAboutX(2, 3.0, v);
            //  Matrix.Translation(1, 0, 4 ,v);
            //  m1.Inverse();
            //   m1.Print();
          //  Matrix.Scaling(3, 3, 3, v);
           // Matrix.Translation(2, 1, 2, v);
            Matrix.RotateVectorAboutX(Math.PI / 2d, v);
            
          
        }
    }
}
