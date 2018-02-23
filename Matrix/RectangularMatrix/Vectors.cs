using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MatrixOperations
// Defining Vector for basic matrix operations
{
    public struct Vector
    {   // X coordinate of Vector
        public double x;
        // Y coordinate of Vector
        public double y;
        // Z coordinate of Vector
        public double z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }
    }
}