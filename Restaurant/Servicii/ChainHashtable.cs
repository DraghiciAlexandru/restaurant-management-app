using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Servicii
{
    class ChainHashtable<K, V>
    {
        private ListaSimpla<Stored<K, V>>[] hashtable;

        public ChainHashtable()
        {
            hashtable = new ListaSimpla<Stored<K, V>>[100];

            for(int i = 0; i < hashtable.Length; i++)
            {
                hashtable[i] = new ListaSimpla<Stored<K, V>>();
            }
        }

        private int hashKey(K key)
        {
            return Math.Abs(key.GetHashCode()) % hashtable.Length;
        }

        public void put(K key, V value)
        {
            int pozitie = hashKey(key);
            hashtable[pozitie].addFinish(new Stored<K, V>() { Key = key, Value = value });
        }

        public V get(K key)
        {
            int pozitie = hashKey(key);
            for (int i = 0; i < hashtable[pozitie].size(); i++) 
            {
                if (hashtable[pozitie].getAtPosition(i).Key.Equals(key))
                    return hashtable[pozitie].getAtPosition(i).Value;
            }
            return default;
        }

        public override string ToString()
        {
            String text = "";
            for (int i = 0; i < hashtable.Length; i++) 
            {
                if (hashtable[i].getIterator() != null)
                    text += hashtable[i].ToString() + Environment.NewLine;
            }
            return text;
        }

        public void remove(K key)
        {
            int pozitie = hashKey(key);
            for (int i = 0; i < hashtable[pozitie].size(); i++)
            {
                if (hashtable[pozitie].getAtPosition(i).Key.Equals(key))
                    hashtable[pozitie].deletePosition(i);
            }
        }

        public ListaSimpla<K> getKeys()
        {
            ListaSimpla<K> lista = new ListaSimpla<K>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i].getIterator() != null)
                {
                    for (int j = 0; j < hashtable[i].size(); j++)
                        lista.addFinish(hashtable[i].getAtPosition(j).Key);
                }
            }
            return lista;
        }

        public ListaSimpla<V> getValues()
        {
            ListaSimpla<V> lista = new ListaSimpla<V>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i].getIterator() != null)
                {
                    for (int j = 0; j < hashtable[i].size(); j++)
                        lista.addFinish(hashtable[i].getAtPosition(j).Value);
                }
            }
            return lista;
        }

    }
}
