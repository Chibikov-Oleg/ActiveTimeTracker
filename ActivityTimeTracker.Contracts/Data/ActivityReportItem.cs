using System;
using JetBrains.Annotations;

namespace ActivityTimeTracker.Contracts.Data
{
    public sealed class ActivityReportItem
    {
        public ActivityReportItem(PeriodType periodType, [NotNull] StatusChangeEvent startEvent, [CanBeNull] StatusChangeEvent endEvent)
        {
            if (startEvent == null)
            {
                throw new ArgumentNullException(nameof(startEvent));
            }

            PeriodType = periodType;
            IsSuppressed = startEvent.IsSuppressed;
            Start = startEvent.CreatedDate;
            End = endEvent?.CreatedDate;
            StartEventId = startEvent.Id;
            Period = End != null ? End.Value - Start : (TimeSpan?)null;
        }

        public DateTime? End { get; }

        public bool IsSuppressed { get; }

        public TimeSpan? Period { get; }

        public PeriodType PeriodType { get; }

        public DateTime Start { get; }

        public int StartEventId { get; }
    }
}