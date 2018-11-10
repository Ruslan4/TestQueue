using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace MyQueue
{
    [Serializable]
    public class MyQueue<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private T[] _array;
        private static T[] _emptyArray;
        private const long _GrowFactor = 200L;
        private int _head;
        private const int _MinimumGrow = 4;
        private object _syncRoot;
        private int _tail;
        private int _version;
        public int Count { get; private set; }

        public delegate void MyQueueStateHandler<T>(object sender, MyQueueEventArgs<T> e);
        public event MyQueueStateHandler<T> EnqueueEvent;
        public event MyQueueStateHandler<T> DequeueEvent;
        public event MyQueueStateHandler<T> ClearEvent;

        static MyQueue()
        {
            _emptyArray = new T[0];
        }

        public MyQueue()
        {
            _array = _emptyArray;
        }

        public MyQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            Count = 0;
        }

        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_array, _head, Count);
            }
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }
            _head = 0;
            _tail = 0;
            Count = 0;
            _version++;
            ClearEvent?.Invoke(this, new MyQueueEventArgs<T>("Event from clear!"));
        }

        public bool Contains(T item)
        {
            int index = _head;
            int num2 = Count;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (num2-- > 0)
            {
                if (item == null)
                {
                    if (_array[index] == null)
                    {
                        return true;
                    }
                }
                else if ((_array[index] != null) && comparer.Equals(_array[index], item))
                {
                    return true;
                }
                index = (index + 1) % _array.Length;
            }
            return false;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            T local = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            Count--;
            _version++;

            DequeueEvent?.Invoke(this, new MyQueueEventArgs<T>("Event from Dequeue", local));

            return local;
        }

        public void Enqueue(T item)
        {
            if (Count == _array.Length)
            {
                int capacity = (int)((_array.Length * _GrowFactor) / 100L);
                if (capacity < (_array.Length + _MinimumGrow))
                {
                    capacity = _array.Length + _MinimumGrow;
                }
                SetCapacity(capacity);
            }
            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            Count++;
            _version++;

            EnqueueEvent?.Invoke(this, new MyQueueEventArgs<T>("Event from Enqueue", item));
        }

        private void SetCapacity(int capacity)
        {
            T[] destinationArray = new T[capacity];
            if (Count > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, destinationArray, 0, Count);
                }
                else
                {
                    Array.Copy(_array, _head, destinationArray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, destinationArray, _array.Length - _head, _tail);
                }
            }
            _array = destinationArray;
            _head = 0;
            _tail = (Count == capacity) ? 0 : Count;
            _version++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _array[_head];
        }

        internal T GetElement(int i)
        {
            return this._array[(this._head + i) % this._array.Length];
        }

        public Enumerator<T> GetEnumerator()
        {
            return new Enumerator<T>((MyQueue<T>)this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator<T>((MyQueue<T>)this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>((MyQueue<T>)this);
        }

        public struct Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
        {
            private MyQueue<T> _q;
            private int _index;
            private int _version;
            private T _currentElement;
            internal Enumerator(MyQueue<T> q)
            {
                _q = q;
                _version = _q._version;
                _index = -1;
                _currentElement = default(T);
            }

            public void Dispose()
            {
                _index = -2;
                _currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (_version != _q._version)
                {
                    throw new InvalidOperationException();
                }
                if (_index == -2)
                {
                    return false;
                }
                _index++;
                if (_index == _q.Count)
                {
                    _index = -2;
                    _currentElement = default(T);
                    return false;
                }
                _currentElement = _q.GetElement(_index);
                return true;
            }

            public T Current
            {

                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                        {
                            throw new InvalidOperationException();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    return _currentElement;
                }
            }

            object IEnumerator.Current
            {

                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                        {
                            throw new InvalidOperationException();
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }
                    }
                    return _currentElement;
                }
            }

            void IEnumerator.Reset()
            {
                if (_version != _q._version)
                {
                    throw new InvalidOperationException();
                }
                _index = -1;
                _currentElement = default(T);
            }
        }
    }

    public class MyQueueEventArgs<T>
    {

        public string Message { get; }
        public T Item { get; }

        public MyQueueEventArgs(string mes, T item)
        {
            Message = mes;
            Item = item;
        }

        public MyQueueEventArgs(string mes)
        {
            Message = mes;
        }
    }
}
