using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Test.Entity
{
    public class Base
    {
        [PropertiesInfo("GUID", true)]
        public Guid GUID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
