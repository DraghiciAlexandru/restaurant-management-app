using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Servicii
{
    class Stored<K, V>
    {
        private K key;

        private V value;

        public K Key
        {
            get { return key; }
            set { key = value; }
        }

        public V Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            String text = "";
            text += key.ToString() + Environment.NewLine;
            text += value.ToString();
            return text;
        }

    }
}
