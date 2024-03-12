using System;
using System.Collections;
using System.Collections.Generic;


public class ArrayList<T> : IEnumerable<T>
{ 
    internal T[] array;
    public int Capacity { get; private set; }
    public int Count { get; private set; }
    public bool IsReadOnly { get; private set; }

    private const int DEFAULT_CAPACITY = 16;
    public T this[int index] 
    {
        get { return array[index]; }
        set { array[index] = value; }
    
    }

    public ArrayList() 
    { 
        array = new T[DEFAULT_CAPACITY];
    }

    public ArrayList(int capacity) 
    {
        Capacity = capacity;
        array = new T[Capacity];
    }

    public ArrayList(IEnumerable<T> collection)
    {
        int capacity = 0;
        foreach (T item in collection) 
        {
            capacity++;
        }
        Capacity = capacity;

        array = new T[Capacity];
        
        int i = 0;
        foreach (T item in collection)
        {
            array[i++] = item;
        }
    }

} 

