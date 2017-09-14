namespace SDMTDDAssignment3.BLL
{
    public interface IBusFare
    {
        /// <summary>
        /// Get the total cost of a bus fare
        /// </summary>
        /// <param name="noOfPassengers">Amount of passengers riding the bus</param>
        /// <param name="kilometer">Kilometers for the fare</param>
        /// <returns>TotalCost as double</returns>
        double TotalCost(int noOfPassengers, int kilometer);
    }
}