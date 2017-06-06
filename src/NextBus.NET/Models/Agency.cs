namespace NextBus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Agency
    {
        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        public string ShortTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegionTitle { get; set; }

        public override bool Equals(object other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (!(other is Agency))
            {
                return false;
            }
            var otherAgency = (Agency)other;
            return Equals(Tag, otherAgency.Tag);
        }

        public override int GetHashCode()
        {
            return Tag?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Agency left, Agency right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Agency left, Agency right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Tag: {0}, Title: {1}, RegionTitle: {2}", Tag, Title, RegionTitle);
        }
    }
}