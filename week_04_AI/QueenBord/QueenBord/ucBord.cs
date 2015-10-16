using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace QueenBord
{
    public class ucBord : Grid
    {

        public ucBord()
        {
        }

        public void maakBord(int N)
        {
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();

            for(int i=0; i<N; i++)
            {
                this.RowDefinitions.Add(new RowDefinition());
                this.ColumnDefinitions.Add(new ColumnDefinition());
            }

            this.ShowGridLines = true;
            drawQueens(N);
        }

        private void drawQueens(int N)
        {
            NQueenSolver queenSolver = new NQueenSolver(N);
            Boolean[,] bord = queenSolver.SolveQueenBord();

            this.Children.Clear();
            for (int row = 0; row < N; row++)
            {
                for(int col = 0; col < N; col++)
                {
                    if (bord[row, col])
                    {
                        Rectangle rect = new Rectangle();
                        rect.Fill = Brushes.Red;
                        

                        this.Children.Add(rect);
                        Grid.SetRow(rect, row);
                        Grid.SetColumn(rect, col);
                    }
                }
            }
        }
    }
}
