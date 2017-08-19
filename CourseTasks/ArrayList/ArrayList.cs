using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class ArrayList<T> : IList<T>
    {
        private T[] array;
        private int count = 0;

        public ArrayList(int capacity)
        {
            array = new T[capacity];
        }
        public ArrayList()
        {
            array = new T[100];
        }
        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }

        }
        public T this[int index]
        {

            get
            {
                if ((index < 0) || (index >= count))
                {
                    throw new ArgumentOutOfRangeException("Индекс находится вне границ списка");
                }
                return array[index];
            }
            set
            {
                if ((index < 0) || (index >= count))
                {
                    throw new ArgumentOutOfRangeException("Индекс находится вне границ списка");
                }
                array[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            int indexNotFound = -1;
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return indexNotFound;
        }

        public void Insert(int index, T item)
        {
            if ((index < 0) || (index > count))
            {
                throw new ArgumentOutOfRangeException("Индекс находится вне границ списка");
            }
            if (count >= array.Length)
            {
                IncreaseCapacity();
            }
            array[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= count))
            {
                throw new ArgumentOutOfRangeException("Индекс находится вне границ списка");
            }
            if (index < Count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                count--;
            }
        }

        public void Add(T item)
        {
            if (count >= array.Length)
            {
                IncreaseCapacity();
            }
            array[count] = item;
            count++;
        }

        private void IncreaseCapacity()
        {
            T[] old = array;
            array = new T[old.Length * 2];
            Array.Copy(old, 0, array, 0, old.Length);
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            IEnumerable<T> elements = array.Where<T>(t => t.Equals(item));
            if (elements.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((arrayIndex < 0) || (arrayIndex >= count))
            {
                throw new ArgumentOutOfRangeException("Индекс находится вне границ списка");
            }
            int index = arrayIndex;
            for (int i = 0; i < count - arrayIndex; i++)
            {
                array[i] = this.array[index];
                index++;
            }
        }

        public bool Remove(T item)
        {
            RemoveAt(IndexOf(item));
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("\n");
                sb.Append(array[i]);
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimToSize()
        {
            T[] arrayTrim = new T[count];
            CopyTo(arrayTrim, 0);
            array = new T[count];
            Array.Copy(arrayTrim, array, count);
        }

        public void EnsureCapacity(int capacityNew)
        {
            T[] arrayNew = array;
            array = new T[capacityNew];
            Array.Copy(arrayNew, array, count);
        }
    }
}
