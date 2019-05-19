using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySetCollection
{
    class MySetCollection
    {
        private ArrayList ArrayList { get; set; }

        public MySetCollection()
        {
            ArrayList = new ArrayList();
        }

        public void Add(object toAdd)
        {
            if (!ArrayList.Contains(toAdd))
            {
                ArrayList.Add(toAdd);
            }

        }

        public void Remove(object toDel)
        {
            ArrayList.Remove(toDel);
        }
    }
}
