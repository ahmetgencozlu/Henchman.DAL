using DataAccessLayer.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.Test.Entity
{
    [TableInfo("TBLUser")]
    public class User
    {
        [PropertiesInfo("Id", true)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
