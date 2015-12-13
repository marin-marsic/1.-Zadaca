using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {

        IGenericList<T> _collection;
        int _position;

        public GenericListEnumerator(IGenericList<T> collection)
        {
            _collection = collection;
            _position = 0;
        }

        public bool MoveNext()
        {
            // Zove se prije svake iteracije.
            // Vratite true ako treba ući u iteraciju, false ako ne
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se
            // nalazimo u kolekciji

            if (_position < _collection.Count)
            {
                return true;
            }

            return false;
        }

        public T Current
        {
            get
            {
                // Zove se na svakom ulasku u iteraciju
                // Hint: Koristite stanje postavljeno u MoveNext() dijelu
                // kako bi odredili što se zapravo vraća u ovom koraku
                return _collection.GetElement(_position++);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            // Ignorirajte
        }

        public void Reset()
        {
            // Ignorirajte
        }
    }
}
