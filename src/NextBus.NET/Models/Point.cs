namespace NextBus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Point
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Lat { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Lon { get; internal set; }

        public override string ToString()
        {
            return string.Format("Lat: {0}, Lon: {1}", Lat, Lon);
        }
    }
}