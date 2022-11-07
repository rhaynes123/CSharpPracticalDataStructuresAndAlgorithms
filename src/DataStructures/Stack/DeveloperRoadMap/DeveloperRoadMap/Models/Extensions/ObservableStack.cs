using System;
using System.Collections.ObjectModel;

namespace DeveloperRoadMap.Models.Extensions
{
    public class ObservableStack<T>: ObservableCollection<T>
    {
        public ObservableStack(): base()
        {
        }

        public void Push(T item)
        {
            base.Add(item);
        }
        public void Pop()
        {
            base.Remove(base.Items.Last());
        }
    }
}

