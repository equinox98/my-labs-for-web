using Pipeline.Algorithms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Algorithms
{
    public static class Network
    {
        public const int Infinity = 99999;

        /// <summary>
        /// Returns adjacency matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[,] GetAdjacencyMatrix(int[,] matrix)
        {
            FloidUorshall(Initialization.Reader.GetLength(), matrix);
            return matrix;
        }


        public static Route Kruskall(int[,] matrix, int k1 = 0, int k2 = 0)
        {
            //resulted road
            Route route = new Route();

            //length and new adjacency matrix
            int length = Initialization.Reader.GetLength();
            bool[,] adjacency = new bool[length, length];

            //set all to false
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    adjacency[i, j] = false;
                }
            }

            //list of used roads
            List<int> used = new List<int>();

            //while not all nodes are used
            while(route.Capacity != length - 1)
            {
                //get min road
                Coordinate min = FindMin(matrix, length, k1, k2);

                

                //insert to the test matrix


                //if there are not any cycles 
                //in the test matrix
                //add to the result
                adjacency[min.X, min.Y] = true;

                if (IsCycle(adjacency, length, min.X))
                {
                    adjacency[min.X, min.Y] = false;
                    continue;
                }
                else
                {
                    if(!used.Contains(min.X))
                    {
                        used.Add(min.X);
                    }

                    if(!used.Contains(min.Y))
                    {
                        used.Add(min.Y);
                    }

                    Road r = new Road();
                    r.From = min.X;
                    r.To = min.Y;

                    route.Add(r);

                    //set this road to Infinity
                    matrix[min.X, min.Y] = Infinity;
                    matrix[min.Y, min.X] = Infinity;
                }
            }





            return route;
        }


        #region Helpers

         
        //find cycles
        private static bool IsCycle(bool[,] matrix, int length, int target)
        {

            return FindCycles(matrix, length, new List<int>(), target);
        }

        private static bool FindCycles(bool[,] matrix, int length, List<int> visited, int current)
        {
            for(int i = 0; i < length; i++)
            {
                //if we have a road
                if(matrix[current, i])
                {
                    //cycle was founded
                    if(visited.Contains(i))
                    {
                        return true;
                    }
                    else
                    {
                        FindCycles(matrix, length, visited, i);
                    }
                }
            }

            //add to visited
            visited.Add(current);
            return false;
        }


        //find min road in the matrix
        private static Coordinate FindMin(int[,] matrix, int length, int k1 = 1, int k2 = 1)
        {
            Coordinate coordinate = new Coordinate();
            coordinate.X = 0;
            coordinate.Y = 0;

            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    if(matrix[coordinate.X, coordinate.Y] * k1 * k2 > matrix[i, j] * k1 * k2 && matrix[i, j] != Infinity)
                    {
                        coordinate.X = i;
                        coordinate.Y = j;
                    }
                }
            }

            return coordinate;
        }




        //implementation of Floid Uorshall algorithm
        private static void FloidUorshall(int n, int[,] d)
        {
            for (int k = 0; k < n; ++k)
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        if (d[i, k] < Infinity && d[k, j] < Infinity)
                            d[i, j] = System.Math.Min(d[i, j], d[i, k] + d[k, j]);
        }


        #endregion


        #region Coordinate

        private struct Coordinate
        {
            public int X;
            public int Y;
        }

        #endregion

    }
}
