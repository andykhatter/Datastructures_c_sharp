using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DataStructures
{
    class CustomStack
    {
        private int p_index;
        private ArrayList list;
        public CustomStack()
        {
            list = new ArrayList();
            p_index = -1;
        }
        public int count
        {
            get { return list.Count; }
        }

        public void push(object item)
        {
            list.Add(item);
            p_index++;
        }

        public object pop()
        {
            object obj = list[p_index];
            list.RemoveAt(p_index);
            p_index--;
            return obj;
        }

        public void clear()
        {
            list.Clear();
            p_index = -1;

        }

        public object peek()
        {
            return list[p_index];
        }
    }
}
