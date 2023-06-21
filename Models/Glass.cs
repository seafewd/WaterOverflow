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

        // fill a glass - the time it takes to fill a glass depends on the number of non-null parents
        public double Fill()
        {
            var parents = new List<Glass> { LeftParent, RightParent };
            var numberOfNotNullParents = parents.Count(p => p != null);
            // two parents, 5s to fill glass
            if (numberOfNotNullParents == 2)
            {
                return 5.0;
            }
            // one parent, 20s to fill glass
            else if (numberOfNotNullParents == 1)
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
