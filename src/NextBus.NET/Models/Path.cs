using System.Linq;

namespace NextBus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Path
    {
        /// <summary>
        /// 
        /// </summary>
        public Point[] Points { get; internal set; }

        public override string ToString()
        {
            return string.Format("Points: {0}", Points.Count());
        }
    }
}