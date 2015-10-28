using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{

    /// <summary>
    /// A class for every point
    /// </summary>
    public class Point
    {
        double x, y;
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Get the distance between this point with another point
        /// </summary>
        /// <param name="p">another point</param>
        /// <returns>the distance</returns>
        public double Distance(Point p)
        {
            return Math.Sqrt((p.X - this.X) * (p.X - this.X) + (p.Y - this.Y) * (p.Y - this.Y));
        }

        /// <summary>
        /// Print a point
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}
