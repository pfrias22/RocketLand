using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLand
{
    public class LandingArea
    {
        private int _totalSize = 100;
        private LandingPosition[,] _landingArea = null;
        private int correctPositionA = 5;
        private int correctPositionB = 15;
        
        public LandingArea(int size = 100)
        {
            _totalSize = size;
            _landingArea = new LandingPosition[_totalSize, _totalSize];

            CreateLandingArea(_landingArea);
        }

        private void CreateLandingArea(LandingPosition[,] landingArea)
        {
            LandingPosition landingPosition = null;

            for (int i = 0; i < _totalSize; i++)
            {
                for (int j = 0; j < _totalSize; j++)
                {
                    landingPosition = new LandingPosition
                    {
                        Checked = false,
                        CorrectPosition = false,
                        X = i,
                        Y = j
                    };

                    if (i >= correctPositionA && i < correctPositionB &&
                        j >= correctPositionA && j < correctPositionB)
                    {
                        landingPosition.CorrectPosition = true;
                    }

                    landingArea[i, j] = landingPosition;
                }
            }
        }

        public string CanLand(int x, int y) 
        {
            string response = "";

            if(_landingArea[x, y].CorrectPosition)
            {
                if (_landingArea[x, y].Checked)
                {
                    response = "clash";
                }
                else
                {
                    if(ClosePositionChecked(x, y))
                    {
                        response = "clash";
                    }
                    else
                    {
                        response = "ok for landing";
                        _landingArea[x, y].Checked = true;
                    }
                }
            }
            else
            {
                response = "out of platform";
            }

            return response;
        }

        private bool ClosePositionChecked(int x, int y)
        {
            bool positionChecked = false;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (_landingArea[i,j].Checked && x != i && y != j)
                    {
                        positionChecked = true;
                    }
                }
            }

            return positionChecked;
        }
    }
}
