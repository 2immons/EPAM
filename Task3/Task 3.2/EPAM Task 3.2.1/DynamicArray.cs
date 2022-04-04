using System.Collections;

namespace EPAM_3_2_1
{
    
    class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        protected T[] _arr;
        public DynamicArray()
        {
            _arr = new T[8];
        }
        public DynamicArray(int n)
        {
            _arr = new T[n];
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new ArgumentOutOfRangeException(nameof(index));

                else
                    return _arr[index];
            }

            set
            {
                if (index < 0 || index >= Length)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _arr[index] = value;
            }
        }

        public int Length { get; private set; }
        public int Capacity { get => _arr.Length; }

        public DynamicArray(IEnumerable<T> col)
        {
            _arr = col.ToArray();
        }

        public T[] ToArray()
        {
            T[] arr = new T[Length];
            Array.Copy(_arr, arr, Length);
            return arr;
        }

        public void Add(T item)
        {
            if (Length == Capacity)
                Array.Resize(ref _arr, _arr.Length * 2);
            _arr[Length] = item;
            Length++;
        }

        public void AddRange(ICollection<T> col)
        {
            if (col.Count > (Capacity - Length))
                Array.Resize(ref _arr, Length + col.Count);

            foreach (var item in col)
            {
                _arr[Length] = item;
                Length++;
            }
        }

        public bool Insert(int index, T item)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (Length == Capacity)
                Array.Resize(ref _arr, _arr.Length * 2);

            for (int i = Length; i > index; i--)
            {
                _arr[i] = _arr[i - 1];
            }

            Length++;
            _arr[index] = item;
            return true;
        }

        public bool Remove(int index)
        {
            T item = _arr[index];
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            Length--;
            for (int i = index; i < Length; i++)
                _arr[i] = _arr[i + 1];
            return true;
        }

        public object Clone()
        {
            object cloneArray = new DynamicArray<T>(ToArray());
            return cloneArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)ToArray()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ToArray().GetEnumerator();
        }
    }
}
