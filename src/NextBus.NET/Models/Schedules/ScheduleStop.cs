using System;

namespace NextBus.NET.Models.Schedules
{
    /// <summary>
    /// 
    /// </summary>
    public class ScheduleStop
    {
        private DateTimeOffset? _time;

        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long EpochTime { get; set; }

        public DateTimeOffset? Time => _time ?? (_time = DateTimeOffset.FromUnixTimeMilliseconds(EpochTime));

        public override string ToString()
        {
            return string.Format("Tag: {0}, EpochTime: {1}", Tag, EpochTime);
        }
    }
}