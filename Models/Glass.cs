using System.Transactions;

namespace WaterOverflow.Models
{
    internal class Glass
    {

        public Glass LeftParent { get; set; }
        public Glass RightParent { get; set; }
        List<Glass> Parents = new List<Glass>();
        private int _NumberOfNotNullParents;
        public readonly double _FillTime;

        public Glass(Glass leftParent = null, Glass rightParent = null)
        {
            if (leftParent != null)
            {
                LeftParent = leftParent;
                Parents.Add(leftParent);
                
            }
            if (rightParent != null)
            {
                RightParent = rightParent;
                Parents.Add(rightParent);
            }

             _NumberOfNotNullParents = Parents.Count(p => p != null);
            _FillTime = SetGlassFillTime();
        }

        private double SetGlassFillTime()
        {
            // two parents, 5s to fill glass
            if (_NumberOfNotNullParents == 2)
            {
                return 5.0;
            }
            // one parent, 20s to fill glass
            else if (_NumberOfNotNullParents == 1)
            {
                return 20.0;
            }
            // no parents, 10s to fill glass
            else
            {
                return 10.0;
            }
        }
        
    }
}
