namespace NextBus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Prediction
    {
        /// <summary>
        /// 
        /// </summary>
        public long EpochTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeparture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TripTag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AffectedByLayover { get; set; }

        public string Branch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsScheduleBased { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Delayed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DirTag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Vehicle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Block { get; set; }

        public override string ToString()
        {
            return string.Format("Vehicle: {0}, TripTag: {1}, Seconds: {2}, DirTag: {3}", Vehicle, TripTag, Seconds,
                                 DirTag);
        }
    }
}