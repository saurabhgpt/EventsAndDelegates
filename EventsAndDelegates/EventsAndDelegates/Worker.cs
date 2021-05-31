using System;
using static EventsAndDelegators.Program;

namespace EventsAndDelegates
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);
    class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for(int i = 0; i < hours; ++i)
                OnWorkPerformed(i + 1, workType);
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // invoke the event directly
            WorkPerformed?.Invoke(hours, workType);
        }

        protected virtual void OnWorkCompleted()
        {
            EventHandler eventHandlerDel1 = WorkCompleted as EventHandler;

            // invoke the underlying delegate of the event
            if (eventHandlerDel1 != null)
                eventHandlerDel1(this, EventArgs.Empty);

            // invoke the event directly
            if (WorkCompleted != null)
                WorkCompleted(this, EventArgs.Empty);
        }
    }
}
