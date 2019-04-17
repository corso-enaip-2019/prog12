using System;
using System.Collections.Generic;
using System.Text;

namespace CarsAndTrafficLights
{
    class TrafficLight
    {
        public event Switched NowGreen;

        TrafficLight(int id)
        {
            Id = id;
        }

        public void Waiting(Car car)
        {
            NowGreen += car;
        }

        public void NotifyGreen(object sender, EventArgs e)
        {
            if (NowGreen != null)
            {
                NowGreen.Invoke(this);
            }
        }
        int Id { get; }
    }

    public delegate void Switched(object sender, EventArgs e);
}
