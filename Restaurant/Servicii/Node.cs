﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Servicii
{
    public class Node<T>
    {
        private T data;
        private Node<T> next;
        
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
