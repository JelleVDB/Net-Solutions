using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenBord
{
    public class NQueenSolver
    {
        public int N { get; set; }

        public NQueenSolver(int N)
        {
            this.N = N;
        }

        public Boolean[,] SolveQueenBord()
        {
            Boolean[,] bord = new Boolean[N, N];
            return NxNQueenOK(0, bord) ? bord : null;
        }

        private Boolean NxNQueenOK(int step, Boolean[,] bord)
        {

            if(step >= N)
            {
                return true;
            }
            //plaats Q step op Rij step: we overlopen elke van de mogelijke kolommen
            for(int kol = 0; kol<N; kol++)
            {
                bord[step, kol] = true; //zet de koningin

                if(BordStillOK(bord, step, kol))
                {
                    if(NxNQueenOK(step + 1, bord))
                    {
                        return true;
                    }
                }

                bord[step, kol] = false; //verwijder de koningin
            }
            return false;
        }


        private Boolean BordStillOK(Boolean[,] bord, int step, int kol)
        {
            if (!VerticalOK(bord, step, kol))
            {
                return false;
            }
            if(!HorizontalOK(bord, step, kol))
            {
                return false;
            }
            if (!DiagonalLeftOK(bord, step, kol))
            {
                return false;
            }
            if (!DiagonalRightOK(bord, step, kol))
            {
                return false;
            }

            return true;
        }

        private Boolean VerticalOK(Boolean[,] bord, int step, int kol)
        {
            for(int rijtest = 0; rijtest < step; rijtest++){
                if(bord[rijtest, kol])
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean HorizontalOK(Boolean[,] bord, int step, int kol)
        {
            for (int koltest = 0; koltest < kol; koltest++)
            {
                if (bord[step, koltest])
                {
                    return false;
                }
            }
            return true;
        }

        private Boolean DiagonalRightOK(Boolean[,] bord, int step, int kol)
        {
            for(int i=1; i<= step; i++)
            {
                int rijtest = step - i,
                    koltest = kol + i;

                if(koltest >= N)
                {
                    return true;
                }
                if(bord[rijtest, koltest])
                {
                    return false;
                }
            }

            return true;
        }

        private Boolean DiagonalLeftOK(Boolean[,] bord, int step, int kol)
        {
            for (int i = 1; i <= step; i++)
            {
                int rijtest = step - i,
                    koltest = kol - i;
                
                if (koltest < 0)
                {
                    
                    return true;
                }
                if (bord[rijtest, koltest])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
