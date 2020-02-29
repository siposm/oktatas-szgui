using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_visual.Model
{
    class ChainedList<T> : IEnumerator, IEnumerable, INotifyCollectionChanged
    {
        class ListItem
        {
            public T content;
            public ListItem next;
        }
        private ListItem head;
        private ListItem pointer;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OCC(T item)
        {
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        #region enumerator and enumerable interface methods
        public object Current
        {
            get { return pointer.content; }
        }

        public bool MoveNext()
        {
            if (pointer == null)
            {
                pointer = head;
                return true;
            }
            else if (pointer.next != null)
            {
                pointer = pointer.next;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }
        }

        public void Reset()
        {
            pointer = null;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        #endregion

        #region list methods
        public void Insert(T itemToInsert, bool toBeginning)
        {
            ListItem newItem = new ListItem() { content = itemToInsert };

            if (toBeginning)
            {
                newItem.next = head;
                head = newItem;
            }
            else
            {
                if (head == null)
                    head = newItem;
                else
                {
                    ListItem p = head;
                    while (p.next != null)
                        p = p.next;

                    p.next = newItem;
                }
            }

            OCC(itemToInsert);
        }

        public void ProcessFullList()
        {
            ListItem p = head;
            while (p != null)
            {
                // yield return ??? ... return p.content;
                p = p.next;
            }
        }


        #endregion
    }

}
