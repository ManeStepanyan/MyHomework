using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{   
    /// <summary>
    /// NxM (N by M) Matrix
    /// </summary>
    class Matrix
    {   // Number of matrix's rown
        public readonly int Row;
        // Number of matrix's columns
        public readonly int Column;
        // Elements of Matrix
        public double[,] data;
        public double this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        } /// <summary>
          /// Constructing new matrix
          /// </summary>
          /// <param name="row"> Number of rows</param>
          /// <param name="column">Number of columns</param>
        public Matrix(int row = 0, int column = 0)
        {
            this.Row = row;
            this.Column = column;
            data = new double[row, column];

        }
        /// <summary>
        ///  Construct matrix by given array
        /// </summary>
        /// <param name="data"> Array for elements of matrix </param>
        public Matrix(double[,] data)
        {
            this.Row = data.GetLength(0);
            this.Column = data.GetLength(1);
            this.data = new double[Row, Column];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    this.data[i, j] = data[i, j];
                }
            }
        }
        /// <summary>
        /// Adding two matrices
        /// </summary>
        /// <param name="first"> First matrix </param>
        /// <param name="second"> Second matrix </param>
        /// <returns> Sum of matrices</returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            Matrix Sum;
            if (first.Row != second.Row || first.Column != second.Column) throw new Exception("Matrixes should have the same size");
            else
            {
                Sum = new Matrix(first.Row, first.Column);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < first.Column; j++)
                    {
                        Sum[i, j] = first[i, j] + second[i, j];

                    }
                }
            }
            return Sum;
        }
        /// <summary>
        /// Multiplication of two matrices
        /// </summary>
        /// <param name="first"> first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns>Product of matrices</returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            Matrix Product;
            if (first.Column != second.Row) throw new Exception(" Size of first matrix's columns must be equal to the size of second matrix's rows");
            else
            {
                Product = new Matrix(first.Row, second.Column);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < second.Column; j++)
                    {
                        for (int k = 0; k < first.Column; k++)
                        {
                            Product[i, j] += first[i, k] * second[k, j];
                        }
                    }
                }
            }
            return Product;

        }
        /// <summary>
        /// Multiply matrix by some scalar
        /// </summary>
        /// <param name="scalar"> Given scalar </param>
        /// <returns></returns>
        public Matrix MultiplicationbyScalar(double scalar)
        {
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    this.data[i, j] = scalar * data[i, j];
                }
            }
            return this;
        }
        /// <summary>
        /// Finding the smallest element of the matrix
        /// </summary>
        /// <returns> Smallest element</returns>
        public double SmallestElement()
        {
            double min = this.data[0, 0];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    if (this.data[i, j] < min)
                        min = data[i, j];
                }
            }
            return min;
        }
        /// <summary>
        /// Finding the largest element of the matrix
        /// </summary>
        /// <returns> The largest</returns>
        public double LargestElement()
        {
            double max = this.data[0, 0];
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    if (this.data[i, j] > max)
                        max = data[i, j];
                }
            }
            return max;
        } /// <summary>
          /// Transponse matrix(flipping a matrix over its diagonal)
          /// </summary>
          /// <returns> Transponed matrix</returns>
        public Matrix Transpose()
        {
            Matrix Transpose = new Matrix(this.Column, this.Row);
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    Transpose[j, i] = data[i, j];
                }
            }
            return Transpose;
        }
        /// <summary>
        ///  Creating an identity matrix
        /// </summary>
        /// <param name="N"> Number of rows and columns </param>
        /// <returns></returns>
        public Matrix Identity(int N)
        {
            Matrix I = new Matrix(N, N);
            for (int i = 0; i < N; i++)
                I[i, i] = 1;
            return I;
        }
        /// <summary>
        /// Bringing matrix to its row-echelon form
        /// </summary>
        /// <param name="matrix"> Matrix </param>
        /// <returns> Matrix's row-echelon form </returns>
        public Matrix BringMatrixToRowEchelonForm(Matrix matrix)
        {
            int n = matrix.Row;
            Matrix I = Identity(matrix.Row);
            // Forming the block matrix using our matrix and identity matrix I
            Matrix NewMatrix = new Matrix(n, 2 * n);
            // Assigning to NewMatrix(nx2n) elements of our given matrix(nxn)
            for (int numberOfRows = 0; numberOfRows < n; numberOfRows++)
            {
                for (int numberOfColumns = 0; numberOfColumns < n; numberOfColumns++)
                    NewMatrix[numberOfRows, numberOfColumns] = matrix[numberOfRows, numberOfColumns];
            }
            // Assigning to NewMatrix's second part Identity matrix
            for (int numberOfRows = 0; numberOfRows < n; numberOfRows++)
            {
                for (int newNumberOfColumns = n; newNumberOfColumns < 2 * n; newNumberOfColumns++)
                {
                    NewMatrix[numberOfRows, newNumberOfColumns] = I[numberOfRows, newNumberOfColumns - n];
                }
            }
            int rowIndex = 0; int columnIndex = 0;
            while (rowIndex < n && columnIndex < n)
            {
                // if matrix[i,j] is a pivot eliminate all non-zero entries below the pivot
                if (NewMatrix[rowIndex, columnIndex] != 0)
                {
                    for (int nextRow = rowIndex + 1; nextRow < n; nextRow++)
                    { // if matrix[nextRow, columnIndex] is not equal to zero make it 0 by adding to nextRow'th row the i'th row times -matrix[nextRow,columnIndex] / matrix[rowIndex,columnIndex]
                        if (NewMatrix[nextRow, columnIndex] != 0)
                        {
                            double temp = NewMatrix[nextRow, columnIndex] / NewMatrix[rowIndex, columnIndex];
                            for (int newNumberOfColumns = 0; newNumberOfColumns < 2 * n; newNumberOfColumns++)
                                NewMatrix[nextRow, newNumberOfColumns] -= NewMatrix[rowIndex, newNumberOfColumns] * temp;
                        }
                    }
                    rowIndex = rowIndex + 1; columnIndex = columnIndex + 1;

                }
                // else if the columnIndex'th column contains a non zero entry below matrix[rowIndex,ColumnIndex] then swap the rowIndex'th row and k'th row; k=rowIndex+1,.....,n
                else
                {

                    for (int k = rowIndex + 1; k < n; k++)
                    {
                        if (NewMatrix[k, columnIndex] != 0)
                        {
                            for (int newNumberOfColumns = 0; newNumberOfColumns < 2 * n; newNumberOfColumns++)
                            {
                                double holder = NewMatrix[rowIndex, newNumberOfColumns];
                                NewMatrix[rowIndex, newNumberOfColumns] = NewMatrix[k, newNumberOfColumns];
                                NewMatrix[k, newNumberOfColumns] = holder;
                            }

                        }
                    }

                }
            }
            return NewMatrix;

        } 
        /// <summary>
        /// Bringing matrix to reduced row-echelon form(rref) and getting the inverse
        /// </summary>
        /// <returns> Inverse matrix</returns>
        public Matrix Inverse()
        {
            if (this.Row != this.Column) throw new Exception("Matrix is not invertible as it is not square");
            Matrix NewMatrix = BringMatrixToRowEchelonForm(this);
            int Rank = this.Row;
            int Count;
            for (int i = 0; i < NewMatrix.Row; i++)
            {
                Count = 0;
                for (int j = 0; j < NewMatrix.Row; j++)
                {

                    if (NewMatrix[i, j] == 0) Count++;
                }
                if (Count == NewMatrix.Row) Rank--;
            }

            if (Rank != this.Row) throw new Exception("No inverse as rank is not equal to n");
            // Turning pivots to one
            for (int rowIndex = 0; rowIndex < NewMatrix.Row; rowIndex++)
            {
                double temp = NewMatrix[rowIndex, rowIndex];
                for (int newNumberOfColumns = 0; newNumberOfColumns < 2 * NewMatrix.Row; newNumberOfColumns++)
                    NewMatrix[rowIndex, newNumberOfColumns] = NewMatrix[rowIndex, newNumberOfColumns] / temp;


            }
            // Eliminate all non-zero entries above the pivot
            for (int rowIndex = 1; rowIndex < NewMatrix.Row; rowIndex++)

            {
                for (int j = rowIndex - 1; j >= 0; j--)
                {
                    if (NewMatrix[j, rowIndex] != 0)
                    {
                        double temp = NewMatrix[j, rowIndex] * NewMatrix[rowIndex, rowIndex];
                        for (int newNumberOfColumns = 0; newNumberOfColumns < NewMatrix.Row * 2; newNumberOfColumns++)
                            NewMatrix[j, newNumberOfColumns] -= temp * NewMatrix[rowIndex, newNumberOfColumns];
                    }
                }
            }
            // Assigning reverse matrix 
            for (int i = 0; i < Row; i++)
            {
                for (int j = Row; j < 2 * Row; j++)
                {
                    this[i, j - Row] = NewMatrix[i, j];

                }
            }
            return this;
        }
        /// <summary>
        /// Is matrix orthogonal
        /// </summary>
        /// <returns></returns>
        public bool IsOrthogonal()
        {
            if (this.Row != this.Column) throw new Exception("Matrix is not square");
            if (this.Inverse() == this.Transpose()) return true;
            else return false;
        }
        /// <summary>
        /// Matrix rotation operation about X axis
        /// </summary>
        /// <param name="angle"> rotate vector by an angle  </param>
        /// <param name="vector"> vector to be rotated </param>
        public static void RotateVectorAboutX(double angle, Vector vector)
        {
            double[,] Rotation = new double[,] { { 1, 0, 0 }, { 0, Math.Floor(Math.Cos(angle)), -Math.Floor(Math.Sin(angle)) }, { 0, Math.Floor(Math.Sin(angle)), Math.Floor(Math.Cos(angle)) } };
            Matrix RotationMatrix = new Matrix(Rotation);
            Matrix VectorMatrix = new Matrix(3, 1);
            VectorMatrix[0, 0] = vector.x;
            VectorMatrix[1, 0] = vector.y;
            VectorMatrix[2, 0] = vector.z;
            Matrix Result = RotationMatrix * VectorMatrix;
            Console.WriteLine("X =" + Result[0, 0] + " ");
            Console.WriteLine("Y =" + Result[1, 0] + " ");
            Console.WriteLine("Z =" + Result[2, 0] + " ");

        }
        /// <summary>
        /// Matrix rotation operation about Y axis
        /// </summary>
        /// <param name="angle"> rotate vector by an angle  </param>
        /// <param name="vector"> vector to be rotated </param>
        public static void RotateVectorAboutY(double angle, Vector vector)
        {
            double[,] Rotation = new double[,] { { Math.Floor(Math.Cos(angle)), -Math.Floor(Math.Sin(angle)), 0 }, { 0, 1, 0 }, { -Math.Floor(Math.Sin(angle)), 0, Math.Floor(Math.Cos(angle)) } };
            Matrix RotationMatrix = new Matrix(Rotation);
            Matrix vectorMatrix = new Matrix(3, 1);
            vectorMatrix[0, 0] = vector.x;
            vectorMatrix[1, 0] = vector.y;
            vectorMatrix[2, 0] = vector.z;
            Matrix Result = RotationMatrix * vectorMatrix;
            Console.WriteLine("X =" + Result[0, 0] + " ");
            Console.WriteLine("Y =" + Result[1, 0] + " ");
            Console.WriteLine("Z =" + Result[2, 0] + " ");

        }
        /// <summary>
        /// Matrix rotation operation about Z axis
        /// </summary>
        /// <param name="angle"> rotate vector by an angle  </param>
        /// <param name="vector"> vector to be rotated </param>
        public static void RotateVectorAboutZ(double angle, Vector vector)
        {
            double[,] Rotation = new double[,] { { Math.Floor(Math.Cos(angle)), -Math.Floor(Math.Sin(angle)), 0 }, { Math.Floor(Math.Sin(angle)), Math.Floor(Math.Cos(angle)), 0 }, { 0, 0, 1 } };
            Matrix RotationMatrix = new Matrix(Rotation);
            Matrix vectorMatrix = new Matrix(3, 1);
            vectorMatrix[0, 0] = vector.x;
            vectorMatrix[1, 0] = vector.y;
            vectorMatrix[2, 0] = vector.z;
            Matrix Result = RotationMatrix * vectorMatrix;
            Console.WriteLine("X =" + Result[0, 0] + " ");
            Console.WriteLine("Y =" + Result[1, 0] + " ");
            Console.WriteLine("Z =" + Result[2, 0] + " ");
        }
        /// <summary>
        /// Scales the 3 dimensional vector
        /// </summary>
        /// <param name="ScalingFactorX">Factor for scaling about X </param>
        /// <param name="ScalingFactorY">Factor for scaling about Y </param>
        /// <param name="ScalingFactorZ">Factor for scaling about Z </param>
        /// <param name="vector"> Vector to be scaled </param>
        public static void Scaling(double ScalingFactorX, double ScalingFactorY, double ScalingFactorZ, Vector vector)
        {
            double[,] scaling = new double[,] { { ScalingFactorX, 0, 0 }, { 0, ScalingFactorY, 0 }, { 0, 0, ScalingFactorZ } };
            Matrix VectorMatrix = new Matrix(3, 1);
            Matrix ScalingMatrix = new Matrix(scaling);
            VectorMatrix[0, 0] = vector.x;
            VectorMatrix[1, 0] = vector.y;
            VectorMatrix[2, 0] = vector.z;

            Matrix result = ScalingMatrix * VectorMatrix;
            Console.WriteLine("Scaling vector in the X direction by " + ScalingFactorX + ":" + result[0, 0]);
            Console.WriteLine("Scaling vector in the Y direction by " + ScalingFactorY + ":" + result[1, 0]);
            Console.WriteLine("Scaling vector in the Z direction by " + ScalingFactorX + ":" + result[2, 0]);

        }



        /// <summary>
        /// Translate the vector in the X, Y, Z direction
        /// </summary>
        /// <param name="x">Value that we want to add to X position</param>
        /// <param name="y">Value that we want to add to y position</param>
        /// <param name="z">Value that we want to add to Z position</param>
        /// <param name="vector"> Vector</param>
        public static void Translation(double x, double y, double z, Vector vector)
        {
            Matrix matrix = new Matrix(4, 4);
            matrix[0, 0] = 1;
            matrix[1, 0] = 0;
            matrix[2, 0] = 0;
            matrix[3, 0] = 0;
            matrix[0, 1] = 0;
            matrix[1, 1] = 1;
            matrix[2, 1] = 0;
            matrix[3, 1] = 0;
            matrix[0, 2] = 0;
            matrix[1, 2] = 0;
            matrix[2, 2] = 1;
            matrix[3, 2] = 0;
            matrix[0, 3] = x;
            matrix[1, 3] = y;
            matrix[2, 3] = z;
            matrix[3, 3] = 1;
            Matrix VectorMatrix = new Matrix(4, 1);
            VectorMatrix[0, 0] = vector.x;
            VectorMatrix[1, 0] = vector.y;
            VectorMatrix[2, 0] = vector.z;
            VectorMatrix[3, 0] = 1;
            Matrix Result = matrix * VectorMatrix;
            Console.WriteLine("Translating X by " + x + ":" + " X =" + Result[0, 0]);
            Console.WriteLine("Translating Y by " + x + ":" + " Y =" + Result[1, 0]);
            Console.WriteLine("Translating Z by " + x + ":" + " Z =" + Result[2, 0]);
        }
        /// <summary>
        /// Printing matrix
        /// </summary>

        public void Print()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
        }

    }
}