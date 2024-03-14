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
        int _capacity = 0;
        foreach (T item in collection) 
        {
            _capacity++;
        }
        Capacity = _capacity;

        array = new T[Capacity];
        
        int i = 0;
        foreach (T item in collection)
        {
            array[i++] = item;
            Count++;
        }
    }

    public void Add(T item)
    {
        if (Count == Capacity)
        {
            Resize(Capacity * 2);
        }
        array[Count++] = item;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException("index");

        if (Count == Capacity)
        {
            Resize(Capacity * 2);
        }

        Array.Copy(array, index, array, index + 1, Count - index);
        array[index] = item;
        Count++;
    }

    public void InsertRange(int index, IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Insert(index++, item);
        }
    }

    public bool Remove(T item)
    {
        int _index = IndexOf(item);
        if (_index >= 0)
        {
            RemoveAt(_index);
            return true;
        }
        return false;
    }

    public void RemoveRange(int index, int count)
    {
        if (index < 0 || index + count > Count)
            throw new ArgumentOutOfRangeException("index");

        Array.Copy(array, index + count, array, index, Count - index - count);
        Count -= count;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException("index");

        Array.Copy(array, index + 1, array, index, Count - index - 1);
        Count--;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public int LastIndexOf(T item)
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void Clear()
    {
        Array.Clear(array, 0, Count);
        Count = 0;
    }

    public T[] ToArray()
    {
        T[] result = new T[Count];
        Array.Copy(array, result, Count);
        return result;
    }

    public void CopyTo(T[] destArray, int arrayIndex)
    {
        Array.Copy(array, 0, destArray, arrayIndex, Count);
    }

    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        Array.Copy(array, newArray, Count);
        array = newArray;
        Capacity = newCapacity;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
} 

