using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySetCollection
{
    class MySetCollection : ArrayList
    {

        public MySetCollection() : base()
        {
        }

        public override int Add(object toAdd)
        {
            if (!base.Contains(toAdd))
            {
                return base.Add(toAdd);
            }

            return -1;
        }

        public override void Remove(object toDel)
        {
            base.Remove(toDel);
        }
    }
}
