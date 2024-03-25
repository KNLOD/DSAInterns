﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;


namespace DataStructures
{
    public class ArrayList<T> : IEnumerable<T>
    {
        internal T[] _array;
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

        public int Capacity { get; private set; }

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
            if (newCapacity == null)
            {
                newCapacity = _array.Length * 2;
                Capacity = (int)newCapacity;
            }
            else if (newCapacity != null)
            {
                Capacity = (int)newCapacity;
            }

            if (Capacity > _array.Length)
            {
                T[] newArray = new T[Capacity];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
            }
            else if (Capacity < _array.Length)
            {
                T[] newArray = new T[Capacity];
                Array.Copy(_array, newArray, Capacity);
                _array = newArray;
            }
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

            int range_count = collection.Count();

            if (index < 0 || index > this._count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than or equal to the size of the collection.");

            if (this._count + range_count > _array.Length)
                Resize(null);

            Array.Copy(_array, index, _array, index + range_count, this._count - index);
            int i = index;
            foreach (T item in collection)
                _array[i++] = item;

            this._count += range_count;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");

            Array.Clear(_array, index, 1);
            _count--;

        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_array, item);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0 || index >= this._count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range. Must be non-negative and less than the size of the collection.");

            if (count < 0 || count > this._count - index)
                throw new ArgumentOutOfRangeException(nameof(count), "Count was out of range. Must be non-negative and less than or equal to the size of the collection.");

            Array.Copy(_array, index + count, _array, index, this._count - index - count);
            Array.Clear(_array, this._count - count, count);
            this._count -= count;
        }

        public int LastIndexOf(T item)
        {
            return Array.LastIndexOf(_array, item, _count - 1, _count);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _count);
            _count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_array, array, _count);
            return array;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Array is null.");

            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Array index was out of range.");

            if (_count > array.Length - arrayIndex)
                throw new ArgumentException("The number of elements in the source ArrayList is greater than the available space from the destination array.");

            Array.Copy(this._array, 0, array, arrayIndex, _count);
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
}