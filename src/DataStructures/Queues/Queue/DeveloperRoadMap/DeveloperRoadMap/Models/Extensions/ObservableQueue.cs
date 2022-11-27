using System;
using System.Collections.ObjectModel;

namespace DeveloperRoadMap.Models.Extensions
{
    public class ObservableQueue<T>: ObservableCollection<T>
    {
        public ObservableQueue(): base()
        {
        }

        public void Push(T item)
        {
            base.Add(item);
        }
        public void Pop()
        {
            base.RemoveAt(0);
        }
    }
}

