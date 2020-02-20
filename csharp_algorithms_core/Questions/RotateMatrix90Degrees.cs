using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterView.Questions
{
    public static class RotateMatrix90Degrees
    {
        public static void Run()
        {
            Console.WriteLine("RotateMatrix90Degrees");

            int N = 4;

            // Test Case 1 
            int[,] mat =
            {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

             displayMatrix(N,mat); 

            rotateMatrix(N, mat);

            // Print rotated matrix 
            displayMatrix(N, mat);

        }
        // An Inplace function to  
        // rotate a N x N matrix 
        // by 90 degrees in anti- 
        // clockwise direction 
        static void rotateMatrix(int N,
                                 int[,] mat)
        {
            // Consider all  
            // squares one by one 
            for (int x = 0; x < N / 2; x++)
            {
                // Consider elements  
                // in group of 4 in  
                // current square 
                for (int y = x; y < N - x - 1; y++)
                {
                    // store current cell  
                    // in temp variable 
                    int temp = mat[x, y];

                    // move values from  
                    // right to top 
                    mat[x, y] = mat[y, N - 1 - x];

                    // move values from 
                    // bottom to right 
                    mat[y, N - 1 - x] = mat[N - 1 - x,
                                            N - 1 - y];

                    // move values from 
                    // left to bottom 
                    mat[N - 1 - x,
                        N - 1 - y] = mat[N - 1 - y, x];

                    // assign temp to left 
                    mat[N - 1 - y, x] = temp;
                }
            }
        }

        // Function to print the matrix 
        static void displayMatrix(int N,
                                  int[,] mat)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }



        /*
        Input
        1  2  3
        4  5  6
        7  8  9

       Output:
        3  6  9 
        2  5  8 
        1  4  7 

       Input:
        1  2  3  4 
        5  6  7  8 
        9 10 11 12 
       13 14 15 16 

       Output:
        4  8 12 16 
        3  7 11 15 
        2  6 10 14 
        1  5  9 13*/


        /*
        First Cycle 
        1  2  3 4 
        5  6  7  8 
        9 10 11 12 
        13 14 15 16 


       Moving first group of four elements (First
       elements of 1st row, last row, 1st column 
       and last column) of first cycle in counter
       clockwise. 
        4  2  3 16
        5  6  7 8 
        9 10 11 12 
        1 14  15 13 

       Moving next group of four elements of 
       first cycle in counter clockwise 
        4  8  3 16 
        5  6  7  15  
        2  10 11 12 
        1  14  9 13 

       Moving final group of four elements of 
       first cycle in counter clockwise 
        4  8 12 16 
        3  6  7 15 
        2 10 11 14 
        1  5  9 13 


       Second Cycle (Involves Blue Elements)
        4  8 12 16 
        3  6 7  15 
        2  10 11 14 
        1  5  9 13 

       Fixing second cycle
        4  8 12 16 
        3  7 11 15 
        2  6 10 14 
        1  5  9 13*/

    }
}
