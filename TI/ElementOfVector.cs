using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI
{
    class ElementOfVector
    {

        private sbyte Value { get; set; }

        public sbyte EV_Value
        {
            get { return Value; }
            set
            {
                if (value == 0 || value == 1)
                {
                    Value = value;
                }
            }
        }

        public ElementOfVector() { Value = 0; }
        public ElementOfVector(sbyte v)
        {
            Value = 0;
            if (v == 0 || v == 1)
            {
                Value = v;
            }
        }

        public ElementOfVector(ElementOfVector ev)
        {
            Value = ev.Value;
        }

        public override string ToString()
        {
            return string.Format("({0})", Value);
        }

        public static ElementOfVector operator +(ElementOfVector ev1, ElementOfVector ev2) { return new ElementOfVector((sbyte)((ev1.Value + ev2.Value) % 2)); }
        public static ElementOfVector operator -(ElementOfVector ev1, ElementOfVector ev2) { return new ElementOfVector((sbyte)((ev1.Value - ev2.Value) % 2)); }
        public static bool operator ==(ElementOfVector ev1, ElementOfVector ev2) { return ev1.Value == ev2.Value; }
        public static bool operator !=(ElementOfVector ev1, ElementOfVector ev2) { return ev1.Value != ev2.Value; }
        public static bool operator false(ElementOfVector ev) { return (ev.Value == 0); }
        public static bool operator true(ElementOfVector ev) { return (ev.Value == 1); }


    }
}
