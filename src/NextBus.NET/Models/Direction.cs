using System;
using System.Linq;

namespace NextBus.NET.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UserForUi { get; set; }

        public string Branch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] StopTags { get; set; }

        public Stop GetStop(string tag)
        {
            if (!StopTags.Contains(tag))
            {
                throw new Exception();
            }
            return new Stop { Tag = tag };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Direction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Tag, Tag);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Direction)) return false;
            return Equals((Direction)obj);
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
        public static bool operator ==(Direction left, Direction right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Direction left, Direction right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("Tag: {0}, Title: {1}, Name: {2}, Stops: {3}", Tag, Title, Name, StopTags.Length);
        }
    }
}