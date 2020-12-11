using System;
using System.Collections.Generic;

namespace WorkflowEngine
{
    class Program
    {

        static void Main(string[] args)
        {
            Workflow workFlow = new Workflow();
            workFlow.Add(new UploadVideo());
            workFlow.Add(new SendEmail());
            workFlow.Add(new ChangeStatus());
            workFlow.Add(new CallWebService());

            var Engine = new WorkflowEngine();
            Engine.Run(workFlow);

            Console.ReadLine();
        }

        public interface IWorkflow
        {
            void Add(ITask task);
            void Remove(ITask task);
            IEnumerable<ITask> GetTasks();
        }

        public interface ITask
        {
            void Execute();
        }

        class ChangeStatus : ITask
        {
            public void Execute()
            {
                Console.WriteLine("Status changing to processing...");
            }
        }

        class CallWebService : ITask
        {
            public void Execute()
            {
                Console.WriteLine("Calling the Web Service...");
            }
        }

        class SendEmail : ITask
        {
            public void Execute()
            {
                Console.WriteLine("Sending an email...");
            }
        }

        class UploadVideo : ITask
        {
            public void Execute()
            {
                Console.WriteLine("Uploading video to storage...");
            }
        }

        public class WorkflowEngine
        {
            public void Run(IWorkflow workflow)
            {
                foreach (ITask I in workflow.GetTasks())
                {
                    try
                    {
                        I.Execute();
                    } catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public class Workflow
        {
            private readonly List<ITask> _tasks;

            public Workflow()
            {
                _tasks = new List<ITask>();
            }

            public void Add(ITask task)
            {
                _tasks.Add(task);
            }

            public void Remove(ITask task)
            {
                _tasks.Remove(task);
            }

            public IEnumerable<ITask> GetTasks()
            {
                //Interface of enumarable, returns a read-only version of task list.
                return _tasks;
            }

            public class ChangeStatus : ITask
            {
                public void Execute()
                {
                    Console.WriteLine("Status changing to processing...");
                }
            }

            public class CallWebService : ITask
            {
                public void Execute()
                {
                    Console.WriteLine("Calling the Web Service...");
                }
            }

            public class SendEmail : ITask
            {
                public void Execute()
                {
                    Console.WriteLine("Sending an email...");
                }
            }

            public class UploadVideo : ITask
            {
                public void Execute()
                {
                    Console.WriteLine("Uploading video to storage...");
                }
            }
        }
    }
}
