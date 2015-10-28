using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    /// <summary>
    /// A pair of points
    /// </summary>
    public class PairOfPoints
    {

        double distance = 0;
        Point point1 = null, point2 = null;

        public PairOfPoints(Point p1, Point p2)
        {
            this.point1 = p1;
            this.point2 = p2;
            // calculate the distance between these two points
            // storage the result, so do not need to calculate every time.
            distance = p1.Distance(p2); 
        }

        /// <summary>
        /// Point 1
        /// </summary>
        public Point Point1
        {
            get {
                return point1;
            }
        }

        /// <summary>
        /// Point 2
        /// </summary>
        public Point Point2
        {
            get
            {
                return point2;
            }
        }

        /// <summary>
        /// Distance between these two points
        /// </summary>
        public double Distance
        {
            get
            {
                return distance;
            }
        }

        /// <summary>
        /// print the pair of points
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}<--->{2}", this.Distance, this.Point1, this.Point2);
        }
    }
}
