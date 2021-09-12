using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Servicii
{
    class SimpleHashTable<K, V>
    {
        private Stored<K, V>[] hashtable;
        
        public SimpleHashTable()
        {
            hashtable = new Stored<K, V>[100];
        }

        //functia hash

        private int hashKey(K key)
        {
            return key.GetHashCode();
        }

        public void put(K key, V value)
        {
            int pozitie = hashKey(key);

            if (ocupied(pozitie))
            {
                Console.WriteLine("Nu avem loc");
            }
            else
            {
                hashtable[pozitie] = new Stored<K, V>();
                hashtable[pozitie].Key = key;
                hashtable[pozitie].Value = value;
            }

        }

        private bool ocupied(int index)
        {
            return hashtable[index] != null;
        }

        private int findKey(K key)
        {
            int pozitie = hashKey(key);

            if (hashtable[pozitie] != null && hashtable[pozitie].Key.Equals(key))
            {
                return pozitie;
            }
            
            int stop = pozitie;

            if (pozitie == hashtable.Length - 1)
            {
                pozitie = 0;
            }
            else
            {
                pozitie++;
            }


            while (pozitie != stop && hashtable[pozitie] != null && !hashtable[pozitie].Key.Equals(key)) 
            {
                
                pozitie = (pozitie + 1) % hashtable.Length;
            }


            if (hashtable[pozitie] != null && hashtable[pozitie].Key.Equals(key)) 
            {
                return pozitie;
            }
            else
            {
                return -1;
            }
           
        }

        public V get(K key)
        {
            int pozitie = findKey(key);

            Console.WriteLine(pozitie);

            if (pozitie != -1)
            {
                return hashtable[pozitie].Value;
            }

            return default;
        }

        public override string ToString()
        {
            String text = "";

            for (int i = 0; i < hashtable.Length; i++) 
            {
                if (hashtable[i] != null)
                    text += hashtable[i].Key.ToString() + Environment.NewLine + hashtable[i].Value.ToString() + Environment.NewLine;
            }

            return text;

        }

        public void remove(K key, V value)
        {
            int pozitie = hashKey(key);

        }

        public ListaSimpla<K> getKeys()
        {
            ListaSimpla<K> lista = new ListaSimpla<K>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i] != null)
                {
                    lista.addFinish(hashtable[i].Key);
                }
            }
            return lista;
        }

        public ListaSimpla<V> getValues()
        {
            ListaSimpla<V> lista = new ListaSimpla<V>();
            for (int i = 0; i < hashtable.Length; i++)
            {
                if (hashtable[i] != null)
                {
                    lista.addFinish(hashtable[i].Value);
                }
            }
            return lista;
        }
    }
}
