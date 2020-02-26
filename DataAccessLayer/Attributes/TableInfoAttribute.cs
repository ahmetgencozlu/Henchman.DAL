using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class TableInfoAttribute : System.Attribute
    {
        private string _TableName;

        public TableInfoAttribute(string TableName)
        {
            this._TableName = TableName;
        }

        public virtual string TableName
        {
            get { return _TableName; }
            set { TableName = value; }
        }
    }
}
