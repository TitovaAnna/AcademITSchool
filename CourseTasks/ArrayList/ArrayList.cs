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
        private int count;

        public ArrayList(int capacity)
        {
            array = new T[capacity];
        }
        public ArrayList() : this(100)
        {
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
            for (int i = 0; i < count; i++)
            {
                if (Equals(array[i], item))
                {
                    return i;
                }
            }
            return -1;
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
            Array.Copy(array, index + 1, array, index, count - index - 1);
            count--;
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
            if (IndexOf(item) != -1)
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

            Array.Copy(this.array, arrayIndex, array, 0, count - arrayIndex);
        }

        public bool Remove(T item)
        {
            try
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(array[0]);
            for (int i = 1; i < count; i++)
            {
                sb.Append(",");
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
            if (array.Length != count)
            {
                T[] arrayTrim = new T[count];
                CopyTo(arrayTrim, 0);
                array = new T[count];
                Array.Copy(arrayTrim, array, count);
            }
        }

        public void EnsureCapacity(int capacityNew)
        {
            if (array.Length != count)
            {
                T[] arrayNew = array;
                array = new T[capacityNew];
                Array.Copy(arrayNew, array, count);
            }
        }
    }
}
