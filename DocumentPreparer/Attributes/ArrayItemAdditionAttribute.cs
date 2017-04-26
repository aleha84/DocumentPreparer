using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Attributes
{
    public enum ArrayItemAdditionType
    {
        AddAsTable,
        AddAsRow
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ArrayItemAdditionAttribute : Attribute
    {
        public ArrayItemAdditionType AdditionType { get; set; }
        public string[] FieldsOrder { get; set; }

        public ArrayItemAdditionAttribute(ArrayItemAdditionType additionType, string[] fieldsOrder = null)
        {
            AdditionType = additionType;
            FieldsOrder = fieldsOrder;
        }

    }
}
