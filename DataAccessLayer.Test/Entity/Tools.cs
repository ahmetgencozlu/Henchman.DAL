using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Test.Entity
{
    [TableInfo("Tools")]
    public class Tools : Base
    {
        public int ActiveLifeCount { get; set; }
        public int ActiveMaintenanceCount { get; set; }
        public int MaxLifeCount { get; set; }
        public int MaxMaintenanceCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
