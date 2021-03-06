﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private int dimension; // We want a perfect square to be the size of the world;

        private Cell[,] _currentworld;
        public Cell[,] CurrentWorld
        {
            get { return _currentworld; }
            set { _currentworld = value; }
        }

        public World(int dimension)
        {
            // minimum dimension is 10
            if (dimension < 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                // create an extra row on top and bottom so each cell has exactly 8 neighbors
                this.dimension = dimension + 2; // <-- That's why we are adding 2
                this._currentworld = new Cell[this.dimension, this.dimension];
                for (int i = 0; i < this.dimension; i++)
                {
                    for (int j = 0; j < this.dimension; j++)
                    {
                        this._currentworld[i, j] = new Cell();
                    }
                }
            }

        }

        // print the contents of the world to the console
        public void DisplayWorld()
        {
            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    Console.Write("{0}", (this._currentworld[i, j].IsAlive ? "*" : " "));
                }
                Console.WriteLine();
            }
        }

        // will seed the world randomly
        public void RamdomlySeedTheWorld()
        {
            Random random = new Random();
            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    this._currentworld[i, j].IsAlive = random.Next(0, 2) == 0 ? false : true;
                }

            }
        }

        public int CountAliveNeighbors(int i, int j)
        {
            int aliveNeighbors = 0;
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    // calculate number of alive neighbors
                    if (k == i && l == j) { 
                        /* center cell, so ignore */ 
                    }
                    else
                    {
                        // check all eight neighbors to see if they are alive
                        if (this._currentworld[k, l].IsAlive)
                        {
                            aliveNeighbors++;
                        }
                    }
                }
            }
            return aliveNeighbors;
        }

        public void ApplyTheRulesOfTheGame()
        {
            int aliveNeighbors;
            // loop through all the cells, but only test the cells that are 1+ row from the edge
            int edge = this.dimension - 1;
            for (int i = 1; i < edge; i++)
            {
                for (int j = 1; j < edge; j++)
                {
                    aliveNeighbors = CountAliveNeighbors(i, j);

                    // apply rules here and set value for next generation
                    /*
                    1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                    2. Any live cell with two or three live neighbours lives on to the next generation.
                    3. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                    */

                    if (this._currentworld[i, j].IsAlive)
                    {
                        if (aliveNeighbors < 2 || aliveNeighbors > 3)
                        {
                            // cell dies
                            this._currentworld[i, j].NextGeneration = false;
                        }
                        else
                        {
                            // cell lives
                            this._currentworld[i, j].NextGeneration = true;
                        }
                    }
                    else
                    {
                        if (aliveNeighbors == 3)
                        {
                            // cell lives
                            this._currentworld[i, j].NextGeneration = true;
                        }
                    }
                }
            }

        }
    }
}