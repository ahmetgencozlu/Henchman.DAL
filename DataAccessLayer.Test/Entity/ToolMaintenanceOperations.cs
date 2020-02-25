using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Test.Entity
{

    [TableInfo("ToolMaintenanceOperations")]
    public class ToolMaintenanceOperations : Base
    {
        public string ToolMaintenanceReasons { get; set; }
    }
}
