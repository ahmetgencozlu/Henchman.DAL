using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Attributes
{
    public class PropertiesInfoAttribute : System.Attribute
    {
        private string _propertyName;
        private bool _isPrimaryKey;
        public PropertiesInfoAttribute(string propertyName, bool isPk)
        {
            _propertyName = propertyName;
            _isPrimaryKey = isPk;
        }

        public string PropertyName { get { return _propertyName; } set { PropertyName = value; } }
        public bool IsPrimaryKey { get { return _isPrimaryKey; } set { IsPrimaryKey = value; } }
    }
}
