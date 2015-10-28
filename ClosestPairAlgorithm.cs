using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    /// <summary>
    /// The algorithm to find a pair of closest points 
    /// </summary>
    public static class ClosestPairAlgorithm
    {

        /// <summary>
        /// Find a pair of closest points from the list of points.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static PairOfPoints Find(List<Point> points)
        {
            if (points == null || points.Count < 2)
            {
                throw new ArgumentException("We need at least two points.");
            }

            // A list of points sorted by X
            List<Point> pointsSortedByX = new List<Point>(points); // copy from points
            pointsSortedByX.Sort((p1, p2) => p1.X.CompareTo(p2.X)); // sort by x
            // A list of points sorted by Y
            List<Point> pointsSortedByY = new List<Point>(points);
            pointsSortedByY.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));

            return FindClosestPair(pointsSortedByX, pointsSortedByY);
        }

        /// <summary>
        /// Find the closest pair of points
        /// </summary>
        /// <param name="pointsSortedByX">the points sorted by x-coodinate</param>
        /// <param name="pointsSortedByY"the points sorted by y-coodinate></param>
        /// <returns></returns>
        static PairOfPoints FindClosestPair(List<Point> pointsSortedByX, List<Point> pointsSortedByY)
        {
            // Less than 2 points, can't find a pair of points, return  null
            if (pointsSortedByX.Count < 2)
            {
                return null;
            }

            // only 2 points, then that 2 points are the pair of closest points
            if (pointsSortedByX.Count == 2)
            {
                return new PairOfPoints(pointsSortedByX[0], pointsSortedByX[1]);
            }

            // split the points to two parts by x-coordinate of point
            var leftPointsSortedByX = pointsSortedByX.Take(pointsSortedByX.Count / 2).ToList();
            var rightPointsSortedByX = pointsSortedByX.Skip(pointsSortedByX.Count / 2).ToList();
            // the x-coordination of the middle line
            var middleX = leftPointsSortedByX.Last().X;

            // split the points which sorted by y-corrdination by the middle line
            var leftPointsSortedByY = pointsSortedByY.Where(p => p.X <= middleX).ToList();
            var rightPointsSortedByY = pointsSortedByY.Where(p => p.X > middleX).ToList();

            // find closest pair points from left and right
            var leftPair = FindClosestPair(leftPointsSortedByX, leftPointsSortedByY);
            var rightPair = FindClosestPair(rightPointsSortedByX, rightPointsSortedByY);

            // get the closer pair from left and right.
            PairOfPoints closestPair;
            if (leftPair == null)
            {
                closestPair = rightPair;
            }
            else if (rightPair == null)
            {
                closestPair = leftPair;
            }
            else
            {
                closestPair = leftPair.Distance < rightPair.Distance ? leftPair : rightPair;
            }

            return FindCloserPairFromDividerArea(pointsSortedByY, middleX, closestPair);
        }

        /// <summary>
        /// Check if there is a closer distance that arround the divider
        /// </summary>
        /// <param name="pointsSortedByY">The points list which sorted by y-coodinate already</param>
        /// <param name="middleX">The x-coodinate of the middle line which split the points into two parts</param>
        /// <param name="closestPair">The closest pair between left part and right part</param>
        /// <returns>
        /// a pair points which distance closer than minDistanse
        /// return null if could not find any
        /// </returns>
        static PairOfPoints FindCloserPairFromDividerArea(List<Point> pointsSortedByY,
            double middleX, PairOfPoints closestPair)
        {
            // find all the points within minDistanse of line middleX.
            var pointsInDividerArea = pointsSortedByY.Where(p => Math.Abs(middleX - p.X) <= closestPair.Distance);

            // Check all points sorted by y-coodinate
            for (int i = 0; i < pointsSortedByY.Count - 1; i++)
            {
                // need to check only the 7 points
                for (int j = i + 1; j < i + 8 && j < pointsSortedByY.Count; j++)
                {
                    // Check if this pair of points closer than minDistanse
                    if (pointsSortedByY[i].Distance(pointsSortedByY[j]) < closestPair.Distance)
                    {
                        closestPair = new PairOfPoints(pointsSortedByY[i], pointsSortedByY[j]);
                    }
                }
            }
            return closestPair;
        }
    }
}
