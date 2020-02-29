using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.Model
{
    class ChainedList<T>
    {
        public ChainedList()
        {
        }

        private ListaElem fej;
        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }

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
