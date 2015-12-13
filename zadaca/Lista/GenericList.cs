using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class GenericList<X> : IGenericList<X>
    {

        private X[] _internalStorage;
        private int _count;

        public GenericList()
        {
            this._internalStorage = new X[4];
            _count = 0;
        }

        public GenericList(int size)
        {
            this._internalStorage = new X[size];
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(X item)
        {
            int size = this.Count;

            if (size == _internalStorage.Length)
            {
                X[] temp = new X[2 * size];

                for (int i = 0; i < size; i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = temp;
            }

            _internalStorage[size] = item;
            _count++;
        }

        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            _count = 0;
        }

        public bool Contains(X item)
        {
            int size = Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public X GetElement(int index)
        {
            if (index >= 0 && index < Count)
            {
                return _internalStorage[index];
            }

            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            int size = this.Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(X item)
        {
            int size = this.Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            int size = Count;

            if (index < 0 || index >= size)
            {
                return false;
            }

            for (int i = index; i < size - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            _count--;
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
