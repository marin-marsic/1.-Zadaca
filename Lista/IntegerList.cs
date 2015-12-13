using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _count;

        public IntegerList()
        {
            this._internalStorage = new int[4];
            _count = 0;
        }

        public IntegerList(int size)
        {
            this._internalStorage = new int[size];
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(int item)
        {
            int size = this.Count;

            if (size == _internalStorage.Length)
            {
                int[] temp = new int[2 * size];

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
            _internalStorage = new int[_internalStorage.Length];
            _count = 0;
        }

        public bool Contains(int item)
        {
            int size = Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetElement(int index)
        {
            if (index >= 0 && index < Count)
            {
                return _internalStorage[index];
            }

            throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
        {
            int size = this.Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(int item)
        {
            int size = this.Count;

            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i] == item)
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
    }
}
