namespace SDMTDDAssignment3.BLL
{
    public class BusFare : IBusFare
    {
        private const double InitialFee = 130.0;
        private const double Below100Fee = 3.20;
        private const double Above100Below500LessThan12PassengersFee = 2.75;
        private const double Above100Below500_12OrMorePassengersFee = 3.00;
        private const double Above500Fee = 2.25;

        private const int HundredDistance = 99;
        private const int FiveHundredDistance = 499;

        public double TotalCost(int noOfPassengers, int kilometer)
        {
            if (kilometer < 100)
            {
                if (kilometer == 0)
                {
                    return InitialFee;
                }
                if (kilometer < 100)
                {
                    return kilometer * Below100Fee + InitialFee;
                }
            }
            if (kilometer < 500)
            {
                if (noOfPassengers < 12)
                {
                    var above100Distance = kilometer - HundredDistance;
                    var belowHundredCost = HundredDistance * Below100Fee;
                    var above100Below500Less12PassengersCost = above100Distance * Above100Below500LessThan12PassengersFee;
                    return belowHundredCost + above100Below500Less12PassengersCost + InitialFee;

                }
                else
                {
                    var above100Distance = kilometer - HundredDistance;
                    var belowHundredCost = (HundredDistance * Below100Fee);
                    var above100Below500_12OrMorePassengersCost = (above100Distance * Above100Below500_12OrMorePassengersFee);

                    return belowHundredCost + above100Below500_12OrMorePassengersCost + InitialFee;
                }
            }
            else
            {
                if (noOfPassengers < 12)
                {
                    var above500Distance = kilometer - FiveHundredDistance;
                    var above100Below500Distance = kilometer - above500Distance - HundredDistance;

                    var above500Cost = above500Distance * Above500Fee;
                    var above100Below500Cost = above100Below500Distance * Above100Below500LessThan12PassengersFee;
                    var hundredCost = HundredDistance * Below100Fee;

                    return above500Cost + above100Below500Cost + hundredCost + InitialFee;
                }
                else
                {
                    var above500Distance = kilometer - FiveHundredDistance;
                    var above100Below500Distance = kilometer - above500Distance - HundredDistance;

                    var above500Cost = above500Distance * Above500Fee;
                    var above100Below500Cost = above100Below500Distance * Above100Below500_12OrMorePassengersFee;
                    var hundredCost = HundredDistance * Below100Fee;

                    return above500Cost + above100Below500Cost + hundredCost + InitialFee;
                }
            }
            return 0;
        }
    }
}