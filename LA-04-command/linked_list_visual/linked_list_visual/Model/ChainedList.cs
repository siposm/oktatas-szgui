using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.Model
{
    class ChainedList<T> : IEnumerator, IEnumerable
    {
        public ChainedList()
        {
        }

        private ListaElem fej;
        private ListaElem bejaro;

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

        #region interface metódusok
        public object Current
        {
            get { return bejaro.tartalom; }
        }

        public bool MoveNext()
        {
            if (bejaro == null)
            {
                // első hívás
                bejaro = fej;
                return true;
            }
            else if (bejaro.kovetkezo != null)
            {
                // n. hívás
                bejaro = bejaro.kovetkezo;
                return true;
            }
            else
            {
                // lista vége
                this.Reset();
                return false;
            }

        }

        public void Reset()
        {
            bejaro = null;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        #endregion

        #region lista metódusok
        public void Beszuras(T elem)
        {
            bool listaelejere = false;

            ListaElem uj = new ListaElem() { tartalom = elem };

            if (listaelejere)
            {
                uj.kovetkezo = fej;
                fej = uj;
            }
            else
            {
                // lista végére
                if (fej == null)
                    fej = uj;
                else
                {
                    ListaElem p = fej;
                    while (p.kovetkezo != null)
                        p = p.kovetkezo;

                    p.kovetkezo = uj;
                }
            }
        }

        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Console.WriteLine(p.tartalom);
                p = p.kovetkezo;
            }
        }
        #endregion
    }

}
