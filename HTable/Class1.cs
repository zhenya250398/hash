using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable

    {
        class KeyValuePair
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        List<List<KeyValuePair>> list;
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            list = new List<List<KeyValuePair>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }
        /// 
        /// Метод складывающий пару ключь-значение в таблицу
        /// 
        /// key">
        /// value">
        public void PutPair(object key, object value)
        {
            var bucketNo = GetBucketNumber(key);
            foreach (var p in list[bucketNo])
            {
                if (Equals(p.Key, key))
                {
                    p.Value = value;
                    return;
                }
            }

            list[bucketNo].Add(new KeyValuePair { Key = key, Value = value });
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствует 
        public object GetValueByKey(object key)
        {
            var BucketNo = GetBucketNumber(key);
            foreach (var p in list[BucketNo])
            {
                if (Equals(p.Key, key))
                {
                    return p.Value;
                }
            }

            return null;
        }

        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }
    }
}