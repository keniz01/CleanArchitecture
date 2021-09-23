namespace CleanArchitecture.Domain.Entities
{
    public class Coordinate
    {
        private Coordinate()
        {
                
        }

        public Coordinate(double latitude, double longitude) : this()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
    }
}