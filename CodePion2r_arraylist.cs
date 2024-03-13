using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ArrayList<T> : IEnumerable<T>
{   internal T[] _array;
    private const int DefaultCapacity = 4;
    private int _count;

    public ArrayList()
    {
        _array = new T[DefaultCapacity];
        _count = 0;
    }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");

        _array = new T[capacity];
        _count = 0;
    }

    public ArrayList(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        _array = collection.ToArray();
        _count = _array.Length;
    }

    public int Capacity
    {
        get => _array.Length;

        set
        {
            if (value < _count)
                throw new ArgumentOutOfRangeException(nameof(value), "Capacity cannot be less than Count.");

            if (value != _array.Length)
            {
                T[] newArray = new T[value];
                Array.Copy(_array, newArray, _count);
                _array = newArray;
            }
        }
    }

    public int Count => _count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");

            return _array[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");

            _array[index] = value;
        }
    }


    public void Add(T item)
    {
        if (_count == _array.Length)
            Resize(null);

        _array[_count++] = item;
    }

    private void Resize(int? newCapacity)
    {
        int capacity = newCapacity ?? _array.Length * 2;
        Capacity = capacity;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        foreach (T item in collection)
            Add(item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");

        if (_count == _array.Length)
            Resize(null);

        Array.Copy(_array, index, _array, index + 1, _count - index);
        _array[index] = item;
        _count++;
    }

    public void InsertRange(int index, IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        int count = collection.Count();

        if (index < 0 || index > _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");

        if (_count + count > _array.Length)
            Resize(null);

        Array.Copy(_array, index, _array, index + count, _count - index);
        int i = index;
        foreach (T item in collection)
            _array[i++] = item;

        _count += count;
    }




    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
            yield return _array[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

