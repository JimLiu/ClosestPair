using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10 points test file:\n");
            ReadAndFindClosetPairPoints("10points.txt");
            Console.WriteLine("\n");
            Console.WriteLine("100 points test file:\n");
            ReadAndFindClosetPairPoints("100points.txt");
            Console.WriteLine("\n");
            Console.WriteLine("1000 points test file:\n");
            ReadAndFindClosetPairPoints("1000points.txt");

            Console.ReadLine();
        }

        /// <summary>
        /// Read file with points and find the closet pair points
        /// </summary>
        /// <param name="filename"></param>
        static void ReadAndFindClosetPairPoints(string filename)
        {
            List<Point> points = ReadPoints(filename);
            if (points == null)
            {
                Console.WriteLine("This file is invlid, please check it agian.");
                return;
            }
            var pair = ClosestPairAlgorithm.Find(points);
            if (pair == null)
            {
                Console.WriteLine("Can't find any pair of points.");
                return;
            }

            Console.WriteLine("The minimum distance is:");
            Console.WriteLine(pair);
        }

        /// <summary>
        /// Read the points from file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        static List<Point> ReadPoints(string filename)
        {
            List<Point> points = new List<Point>();
            string[] lines;
            try {
                lines = File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read file: {0}\n{1}\n{2}", filename, ex.Message, ex.StackTrace);
                return null;
            }
            foreach (string line in lines)
            {
                Point p;
                if (TryParsePoint(line, out p))
                {
                    points.Add(p);
                }
            }
            return points;
        }

        /// <summary>
        /// Try to parse point from a line of string
        /// </summary>
        /// <param name="line">two points split by space</param>
        /// <param name="point">out the point object</param>
        /// <returns>wheather or not parse a point from line</returns>
        static bool TryParsePoint(string line, out Point point)
        {
            point = null;
            if (!string.IsNullOrEmpty(line))
            {
                string[] coords = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (coords.Length >= 2)
                {
                    double x, y;
                    if (double.TryParse(coords[0], out x) && double.TryParse(coords[1], out y))
                    {
                        point = new Point(x, y);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
