using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Test.Entity
{
    [TableInfo("TBLAssets")]
    public class Assets : Base
    {
        public int Type { get; set; }
    }
}
