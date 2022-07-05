using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IIdentifiable
    {
        public string Id { get;}
        bool IsIdValid(string nums);
    }
}
