using System;
using System.Collections.Generic;
using System.Text;

namespace StoreShop.BusinessLogic
{
     public class ChildClass : abstractClass1
    {
        public override int Show()
        {
            return 11;
        }

        public override void Sum()
        {
            throw new NotImplementedException();
        }
    }
}
