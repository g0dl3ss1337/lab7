using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;

public class TaskScheduler<TTask, TPriority>
{
    private readonly SortedDictionary<TPriority, Queue<TTask>> taskQueue;
    private readonly TaskExecution<TTask> taskExecutionDelegate;

    public TaskScheduler(TaskExecution<TTask> executionDelegate)
    {
        taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
        taskExecutionDelegate = executionDelegate;
    }

    public void AddTask(TTask task, TPriority priority)
    {
        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }

        taskQueue[priority].Enqueue(task);
    }

    public int Count
    {
        get
        {
            int count = 0;
            foreach (var queue in taskQueue.Values)
            {
                count += queue.Count;
            }
            return count;
        }
    }


    public void ExecuteNext()
    {
        if (taskQueue.Count > 0)
        {
            TPriority highestPriority = taskQueue.Keys.Max();
            Queue<TTask> tasksWithPriority = taskQueue[highestPriority];

            if (tasksWithPriority.Count > 0)
            {
                TTask task = tasksWithPriority.Dequeue();
                taskExecutionDelegate(task);
            }

            if (tasksWithPriority.Count == 0)
            {
                taskQueue.Remove(highestPriority);
            }
        }
    }
}

public delegate void TaskExecution<TTask>(TTask task);
