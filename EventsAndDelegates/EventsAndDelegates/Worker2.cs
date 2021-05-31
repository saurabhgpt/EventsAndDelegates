using System;
using static EventsAndDelegators.Program;

namespace EventsAndDelegates
{
    //public delegate int WorkPerformedHandlerModified(object sender, WorkPerformedEventArgs e);
    class Worker2
    {
        //public event WorkPerformedHandlerModified WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; ++i)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // invoke the event directly
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
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
