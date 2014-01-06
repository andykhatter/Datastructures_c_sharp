using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DataStructures
{
    public class CustomCollection:CollectionBase
    {
        public void Add(object addObj)
        {
            InnerList.Add(addObj);
        }

        public new void Clear()
        {
            InnerList.Clear();
        }
        // New keyword to override a non-virtual or a static method
        public void Remove(object removeObj)
        {
            InnerList.Remove(removeObj);
        }

        public new int Count()
        {
            return InnerList.Count;   
        }
    }
}
