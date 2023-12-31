﻿namespace WaterOverflow.Models
{
    internal class GameEngine
    {
        private int _Rows;
        private int _GlassIndex;
        private Glass[][] _GlassTower;

        public GameEngine(int rows, int glassIndex) 
        {
            _Rows = rows;
            _GlassIndex = glassIndex;
            /* jagged array for the tower of glasses
               example:
                   x
                   x x
                   x x x
                   x x x x
                   ...
            */
            _GlassTower = new Glass[rows][];
        }

        /// <summary>
        /// Builds tower and fills glasses
        /// </summary>
        /// <returns></returns>
        public double Run()
        {
            BuildGlassTower();
            return GetFillTime();
        }

        /// <summary>
        /// Fill all glasses of the tower array and calculate the total time
        /// </summary>
        /// <returns></returns>
        private double GetFillTime()
        {
            // -1 because both arrays have 0 index
            var glass = _GlassTower[_Rows - 1][_GlassIndex - 1]!;
            return CalculateFillTime(glass);
        }

        /// <summary>
        /// Get the total time it takes for the given glass to fill up
        /// Runs "upwards" recursively from the current glass node
        /// and checks the time it takes for its parents to fill up, and so on...
        /// </summary>
        /// <param name="glass"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFillTime(Glass glass, double time = 0)
        {
            if (glass == null)
            {
                return 0;
            }

            // we only need to keep track of one parent since we're always
            // moving upwards
            var parent = glass.LeftParent ?? glass.RightParent;

            time += glass._FillTime + CalculateFillTime(parent, time);
            return time;
        }

        /// <summary>
        /// build array and populate each row with new Glass objects
        /// where each consecutive row grows in length by 1 
        /// </summary>
        private void BuildGlassTower()
        {
            // initialize jagged 2d array
            for (int i = 0; i < _Rows; i++)
            {
                _GlassTower[i] = new Glass[i + 1];
            }

            // for each column in each row, check if a glass should 
            // have one, two or no parents and set pointers to them
            for (int i = 0; i < _GlassTower.Length; i++)
            {
                for (int j = 0; j < _GlassTower[i].Length; j++)
                {
                    int currentRowLength = _GlassTower[i].Length;
                    int prevRowLength = i < 1 ? 0 : _GlassTower[i - 1].Length;

                    var hasLeftParent = IsValidIndex(prevRowLength, j - 1);
                    var hasRightParent = IsValidIndex(prevRowLength, j);

                    // current node only has a left parent
                    if (hasLeftParent && !hasRightParent)
                    {
                        _GlassTower[i][j] = new Glass(_GlassTower[i - 1][j - 1], null);
                    }
                    // current node only has a right parent
                    else if (!hasLeftParent && hasRightParent)
                    {
                        _GlassTower[i][j] = new Glass(null, _GlassTower[i - 1][j]);
                    }
                    // current node has two parents
                    else if (hasLeftParent && hasRightParent)
                    {
                        _GlassTower[i][j] = new Glass(_GlassTower[i - 1][j - 1], _GlassTower[i - 1][j]);
                    }
                    // current node is the root - create a new Glass without parents
                    else
                    {
                        _GlassTower[i][j] = new Glass();
                    }
                }
            }
        }

        // Check if valid array index access
        public static bool IsValidIndex(int prevRowLength, int colIndex)
        {
            return prevRowLength > colIndex && colIndex >= 0;
        }
    }
}
