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

        #region collection changed interface methods
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OCC_Add(T item)
        {
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        private void OCC_Rem(T item)
        {
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));  // NotifyCollectionChangedAction.Remove nem működött megfelelően
        }
        #endregion

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

            OCC_Add(itemToInsert);
        }

        public void Remove(T itemToDelete)
        {
            ListItem p = head;
            ListItem e = null;
            while (p != null && !p.content.Equals(itemToDelete))
            {
                e = p;
                p = p.next;
            }

            if (p != null)
            {
                if (e == null)
                    head = p.next;
                else
                    e.next = p.next;
                p = null;
            }
            //else throw new Exception("no such requested item is in the list");

            OCC_Rem(itemToDelete);
        }
        #endregion
    }

}
