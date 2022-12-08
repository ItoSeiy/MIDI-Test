using System;
using UnityEngine;

namespace ISDevTemplate.Data
{
    /// <summary>
    /// 値型<T>の2つの値を格納する構造体
    /// </summary>
    /// <typeparam name="T">System.Int32, System.Singleなどの値型</typeparam>
    [Serializable]
    public struct RangeValueStruct<T> where T : struct
    {
        public T Start => _start;

        public T End => _end;

        [SerializeField]
        private T _start;

        [SerializeField]
        private T _end;

        public RangeValueStruct(T start, T end)
        {
            _start = start;
            _end = end;
        }
    }

    /// <summary>
    /// 参照型<T>の範囲(最大値,最小値)を格納するクラス
    /// </summary>
    /// <typeparam name="T">System.Int32, System.Singleなどの値型</typeparam>
    [Serializable]
    public class RangeValueClass<T> where T : class
    {
        public T Start => _start;

        public T End => _end;

        [SerializeField]
        private T _start;

        [SerializeField]
        private T _end;

        public RangeValueClass(T start, T end)
        {
            _start = start;
            _end = end;
        }
    }
}
