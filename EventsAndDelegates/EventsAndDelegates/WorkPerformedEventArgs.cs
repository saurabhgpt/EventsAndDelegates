using static EventsAndDelegators.Program;

namespace EventsAndDelegates
{
    public class WorkPerformedEventArgs: System.EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType workType)
        {
            Hours = hours;
            WorkType = workType;
        }

        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
