﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp8
{
    class Pitcher

    { private int pitchNumber = 0;
        
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler<BallEventArgs>(ball_BallInPlay);
        }

        public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();

        void ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance<95)&&(ballEventArgs.Trajectory<60))
                {
                    CatchBall();
                }
                else
                {
                    CoverFirstBase();
                }
            }
        }

        private void CoverFirstBase()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I covered first base");
        }

        private void CatchBall()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I caught the ball");
        }
    }
}
