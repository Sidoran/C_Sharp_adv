﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections.Generics
{
    public class IteaGenericCollection<T> : IEnumerable<T>, IBaseGenericCollectionUsing<T>
    {
        private T[] collection;
        private IteaGenericEnumerator<T> enumerator;
        private int count = 0;

        #region IBaseGenericCollectionUsing
        public IteaGenericCollection()
        {
            collection = new T[128];
            enumerator = new IteaGenericEnumerator<T>(collection);
            count = 0;
        }

        public void Add(T ts)
        {
            collection[count] = ts;
            count++;
        }

        public void AddMany(T[] ts)
        {
            foreach (T element in ts) {
                Add(element);
            }
        }

        public void Clear()
        {
            collection = new T[128];
            count = 0;
        }

        public T[] GetAll()
        {
            if (count != 0) return collection;
            else return new T[0];
        }

        public T GetByID(int index)
        {
            try
            {
                return collection[index];
            }
            catch (IndexOutOfRangeException)
            {
                ToConsole("IteaGenericCollection/GetByID: IndexOutOfRangeException", ConsoleColor.Red);
                return default(T);
            }
        }

        public void RemoveByID(int index)
        {
            try
            {
                int i = 0;
                while (i < count - index) {
                    collection[index + i] = collection[index + i + 1];
                    i++;
                }
                collection[count] = default(T);
                count--;
            }
            catch
            {
                ToConsole("IteaGenericCollection / GetByID: Cannot remove item", ConsoleColor.Red);
            }
        }

        public IEnumerable<T> NPair() {
            for (int i = 0; i < count; i++) {
                if (i % 2 == 1) yield return collection[i];
             } 
        }

        public void ShowAll()
        {
            int i = 0;
            while (i < count) {
                ToConsole(collection[i].ToString(), ConsoleColor.White);
                i++;
            };
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }
        #endregion
    }
}
