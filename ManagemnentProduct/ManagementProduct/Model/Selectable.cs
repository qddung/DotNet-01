using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementProduct.Model
{
    public class Selectable<T>
    {
        public Selectable()
        {
        }
        public Selectable(T value, string label)
        {
            Label = label;
            Value = value;
        }
        public T Value { get; set; }
        public string Label { get; set; }
    }
}
