using DataAccessLayer.Attributes;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataAccessLayer.Utility
{
    [TableInfo("User")]
    public static class AttributeExtensions
    {
        public static string GetTableAttribute(this Type t)
        {
            TableInfoAttribute att;

            att = (TableInfoAttribute)Attribute.GetCustomAttribute(t, typeof(TableInfoAttribute));

            if (att == null)
            {
                throw new ArgumentException($"No attribute in class {t.ToString()}.\n");
            }
            else
            {
                return att.TableName;
            }
        }

        public static List<PropertiesInfo> GetPropertyAttributes(this Type t)
        {
            var collection = new List<PropertiesInfo>();

            PropertyInfo[] props = t.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    PropertiesInfoAttribute authAttr = attr as PropertiesInfoAttribute;
                    if (authAttr != null)
                    {
                        collection.Add(new PropertiesInfo { PropertName = authAttr.PropertyName, IsPrimaryKey = authAttr.IsPrimaryKey });
                    }
                    else
                    {
                        throw new ArgumentException($"No attribute in class {t.ToString()}.\n");
                    }
                }
            }

            return collection;
        }

        public static PropertiesInfo GetPropertyAttribute(this Type t)
        {
            PropertiesInfoAttribute att;

            att = (PropertiesInfoAttribute)Attribute.GetCustomAttribute(t, typeof(PropertiesInfoAttribute));

            if (att == null)
            {
                throw new ArgumentException($"No attribute in class {t.ToString()}.\n");
            }
            else
            {
                return new PropertiesInfo { PropertName = att.PropertyName, IsPrimaryKey = att.IsPrimaryKey };
            }
        }
    }
}
