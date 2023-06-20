namespace WaterOverflow.Models
{
    internal class Glass
    {

        public Glass LeftParent { get; set; }
        public Glass RightParent { get; set; }

        public Glass(Glass leftParent = null, Glass rightParent = null)
        {
            if (leftParent != null)
            {
                LeftParent = leftParent;
            }
            if (rightParent != null)
            {
                RightParent = rightParent;
            }
        }

        public double Fill()
        {
            var parents = new List<Glass> { LeftParent, RightParent };
            // two parents, 5s to fill glass
            if (parents.Count == 2)
            {
                return 5.0;
            }
            // one parent, 10s to fill glass
            else if (parents.Count == 1)
            {
                return 10.0;
            }
            // no parents, 10s to fill glass
            else
            {
                return 20.0;
            }
        }
    }
}
