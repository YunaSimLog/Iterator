using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern_2
{
    /// <summary>
    /// 반복자 인터페이스
    /// </summary>

    internal interface Iterator
    {
        bool HasNext();
        object Next();
    }

    internal class ConcreteIterator : Iterator
    {
        object[] _arr;
        int _nextIndex = 0; // 찾기 위치 (커서), for문의 i 변수 역할

        // 순회할 컬렉션을 받아 필드에 참조 시킴
        public ConcreteIterator(object[] arr)
        {
            _arr = arr;
        }

        // 순회할 다음 요소가 있는지 true / false
        public bool HasNext()
        {
            return _nextIndex < _arr.Length;
        }

        // 다음 요소를 반환하고 커서를 증가시켜 다음 요소를 바라보도록 한다.
        public object Next()
        {
            return _arr[_nextIndex++];
        }
    }

    // 집합체 인터페이스 (컬렉션)
    internal interface Aggregate
    {
        Iterator CreateIterator();
    }

    internal class ConcreteAggregate : Aggregate
    {
        object[] _arr; // 데이터 집합 (컬렉션)
        int _index = 0;

        public ConcreteAggregate(int size)
        {
            _arr = new object[size];
        }

        public void Add(object obj)
        {
            if (_index < _arr.Length)
            {
                _arr[_index] = obj;
                _index++;
            }
        }

        // 내부 컬렉션을 인자로 넣어 이터레이터 구현체를 클라이언트에 반환
        public Iterator CreateIterator()
        {
            return new ConcreteIterator(_arr);
        }
    }
}
