namespace SDMTDDAssignment.BLL
{
    public interface ISortedBag
    {
        // Add integer
        void Add(int numbers);

        // Retrieve and remove smallest integer
        int Pop();

        // Retrieve the number of integers
        int Count { get; }
    }
}