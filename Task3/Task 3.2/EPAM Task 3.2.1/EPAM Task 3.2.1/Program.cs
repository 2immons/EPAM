using System.Collections;
using System;
using System.Linq;

namespace EPAM_3_2_1
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        private T[] arr;
        public DynamicArray()
        {
            arr = new T[8];
        }
        public DynamicArray(int length)
        {
            arr = new T[length];
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    return arr[index];
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    arr[index] = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public int Capacity() => arr.Length;
        public int Length()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != null) 
                    count++;
            return count;
        }
        public void AddRange(IEnumerable<T> col)
        {
            
        }
        public void Add(T item)
        {
            if (arr[arr.Length - 1] != null )
            {
                Array.Resize(ref arr, arr.Length * 2);
                arr.Append(item);
            }
            else arr.Append(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        //public bool Remove(int index)
        //{
        //    T item = arr[index];
        //    for (int i = index; i < arr.Length; i++)
        //    {
        //        arr[i] = arr[i + 1];
        //    }
        //    if (arr[index] != item) return true;
        //    else return false;
        //}

        public bool Insert(T item, int index)
        {
            try
            {
                for (int i = arr.Length - 1; i >= index; i--)
                {
                    arr[i + 1] = arr[i];
                }
                arr[index] = item;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Out of range exception.");
                return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            DynamicArray<int> arr = new DynamicArray<int>();
            Console.WriteLine(arr.Capacity());
            Console.WriteLine(arr.Length());
            arr.Add(2);
            arr.Add(2);
            Console.WriteLine(arr.Capacity());
            Console.WriteLine(arr.Length());
        }
        
    }
}