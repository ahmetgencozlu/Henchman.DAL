using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Test.Entity
{
    [TableInfo("Fixtures")]
    public class Fixtures: Base
    {
        public bool IsEnable { get; set; }
        public int Order { get; set; }
    }
}
