using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 집합체 생성
            ConcreteAggregate aggregate = new ConcreteAggregate(5);
            aggregate.Add(1);
            aggregate.Add(2);
            aggregate.Add(3);
            aggregate.Add(4);
            aggregate.Add(5);

            // 2. 집합체에서 이터레이터 객체 반환
            Iterator iter = aggregate.CreateIterator();

            // 3. 이터레이터 내부 커서를 통해 순회
            while (iter.HasNext())
            {
                Console.Write($"{iter.Next()} -> ");
            }
        }
    }
}
