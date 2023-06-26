using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        // 현재 요소의 키를 반환 
        public abstract int Key();

        // 현재 요소르 반환
        public abstract object Current();

        // 다음 요소 앞으로 이동
        public abstract bool MoveNext();

        // 첫 번쨰 요소로 돌아가기
        public abstract void Reset();
    }

    // 반복자 집합체
    abstract class IteratorAggregate : IEnumerable
    {
        // 구현을 위해 Iterator 또는 다른 반복자 집합체를 반환한다.
        public abstract IEnumerator GetEnumerator();
    }

    // 반복자는 다양한 순회 알고리즘을 구현한다.
    // 이러한 클래스는 항상 현재 순회 위치를 저장합니다.
    class AlphabeticalOrderIterator : Iterator
    {
        WordsCollection m_collection;

        // 현재 순회 위치를 저장한다.
        // 반복자는 특히 특정 종류의 컬렉션과 함께 작동해야 하는 경우 반복 상태를 저장하기 위한 다른 많은 필드를 가질 수 있습니다.
        int m_nPosition = -1;
        bool m_bReverse = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool bReverse = false)
        {
            m_collection = collection;
            m_bReverse = bReverse;
            if (bReverse)
            {
                m_nPosition = collection.GetItems().Count;
            }
        }

        public override object Current()
        {
            return m_collection.GetItems()[m_nPosition];
        }

        public override int Key()
        {
            return m_nPosition;
        }

        public override bool MoveNext()
        {
            int nUpdatePosition = m_nPosition + (m_bReverse ? -1 : 1);

            if (nUpdatePosition >= 0 && nUpdatePosition < m_collection.GetItems().Count)
            {
                m_nPosition = nUpdatePosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            m_nPosition = m_bReverse ? m_collection.GetItems().Count - 1 : 0;
        }
    }

    // 구체적인 컬렉션은 컬렉션 클래스와 호환되는 새로운 반복자 인스턴스를 검색하기 위한 하나 이상의 메서드를 제공합니다.
    class WordsCollection : IteratorAggregate
    {
        List<string> m_lstCollection = new List<string>();

        bool m_bDirection = false;

        public void ReverseDirection()
        {
            m_bDirection = !m_bDirection;
        }

        public List<string> GetItems()
        {
            return m_lstCollection;
        }

        public void AddItem(string strItem)
        {
            m_lstCollection.Add(strItem);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, m_bDirection);
        }
    }
}
