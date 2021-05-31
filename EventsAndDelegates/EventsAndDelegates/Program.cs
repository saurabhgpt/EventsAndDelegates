using EventsAndDelegates;
using System;

namespace EventsAndDelegators
{
    public class Program
    {
        public delegate void WorkPerformedHandler(int hours, WorkType workType);
        public delegate int WorkPerformedHandlerWithReturn(int hours, WorkType workType);
        public static void Main(string[] args)
        {
            DelegateWork1();
            DelegateWork2();
            DelegateWork3();
            DelegateWork4();

            Worker2 worker2 = new Worker2();
            worker2.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkerWorkPerformed);
            worker2.WorkCompleted += new EventHandler(WorkerWorkCompleted);
            worker2.DoWork(5, WorkType.Golf);
        }

        private static void WorkerWorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work completed");
        }

        private static void WorkerWorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours + " " + e.WorkType);
        }

        private static void DelegateWork4()
        {
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn1 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn1);
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn2 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn2);
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn3 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn3);
            workPerformedHandlerWithReturn1 += workPerformedHandlerWithReturn2 + workPerformedHandlerWithReturn3;
            Console.WriteLine(workPerformedHandlerWithReturn1(8, WorkType.GoTomeetings));
        }

        private static void DelegateWork3()
        {
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn1 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn1);
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn2 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn2);
            WorkPerformedHandlerWithReturn workPerformedHandlerWithReturn3 = new WorkPerformedHandlerWithReturn(workPerformedWithReturn3);
            Console.WriteLine(workPerformedHandlerWithReturn1(5, WorkType.GenerateReports));
            Console.WriteLine(workPerformedHandlerWithReturn2(7, WorkType.Golf));
            Console.WriteLine(workPerformedHandlerWithReturn3(9, WorkType.GoTomeetings));
        }

        private static int workPerformedWithReturn3(int hours, WorkType workType)
        {
            Console.WriteLine("workperformedwithreturn 3 - " + workType.ToString());
            return hours;
        }

        private static int workPerformedWithReturn2(int hours, WorkType workType)
        {
            Console.WriteLine("workperformedwithreturn 2 - " + workType.ToString());
            return hours;
        }

        private static int workPerformedWithReturn1(int hours, WorkType workType)
        {
            Console.WriteLine("workperformedwithreturn 1 - " + workType.ToString());
            return hours;
        }

        private static void DelegateWork2()
        {
            WorkPerformedHandler wp1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler wp2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler wp3 = new WorkPerformedHandler(WorkPerformed3);
            wp1 += wp2 + wp3;
            wp1(7, WorkType.GenerateReports);
        }

        private static void DelegateWork1()
        {
            WorkPerformedHandler wp1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler wp2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPorformed(wp2, 5, WorkType.Golf);
            //wp1(5, WorkType.Golf);
            //wp2(10, WorkType.GoTomeetings);
        }

        static void WorkPorformed(WorkPerformedHandler wph, int hours, WorkType workType)
        {
            wph(hours, workType);
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("Workperformed 1 called - " + hours + " " + workType.ToString());
        }

        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("Workperformed 2 called - " + hours + " " + workType.ToString());
        }

        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("Workperformed 3 called - " + hours + " " + workType.ToString());
        }

        public enum WorkType
        {
            GoTomeetings,
            Golf,
            GenerateReports
        }
    }
}
