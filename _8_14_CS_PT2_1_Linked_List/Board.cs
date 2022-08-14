using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_14_CS_PT2_1_Linked_List
{
	class MyLinkedListNode<T>
	{
		public T Data;
		public MyLinkedListNode<T> Next;
		public MyLinkedListNode<T> Prev;
	}
	class MyLinkedList<T>
	{
		public MyLinkedListNode<T> Head = null;	//첫번째
		public MyLinkedListNode<T> Tail = null;	//마지막
		public int Count = 0;

		//	O(1)
		public MyLinkedListNode<T>AddLast(T data)
		{
			MyLinkedListNode<T> newMyLinkedListNode = new MyLinkedListNode<T>();
			newMyLinkedListNode.Data = data;

			//	만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 곧 Head 이다.
			if (Head ==null)
				Head = newMyLinkedListNode;

			// 기존의 [마지막 방]과 [새로 추가되는 방]을 연결해준다.
			if (Tail != null)
			{
				Tail.Next = newMyLinkedListNode;
				newMyLinkedListNode.Prev = Tail;
			}

			//	[새로 추가되는 방]을 [마지막 방]으로 인정한다.
			Tail = newMyLinkedListNode;
			Count++;
			return newMyLinkedListNode;
		}

		// O(1)
		public void Remove(MyLinkedListNode<T> MyLinkedListNode)
		{
			//	[기존의 첫번째 방의 다음 방]을 [첫번째 방]으로 인정한다.
			if (Head == MyLinkedListNode)
				Head = Head.Next;   //첫번째 방뿐인경우 Head.Next는 null이 된다.

			//	[기존의 마지막 방의 이전 방]을 [마지막 방]으로 인정한다.
			if (Tail == MyLinkedListNode)
				Tail = Tail.Prev;

			if (MyLinkedListNode.Prev != null)
				MyLinkedListNode.Prev.Next = MyLinkedListNode.Next;

			if (MyLinkedListNode.Next != null)
				MyLinkedListNode.Next.Prev = MyLinkedListNode.Prev;
			Count--;
		}
	}
	internal class Board
	{
		public int[] _data = new int[25];
		public MyLinkedList<int> _data3 = new MyLinkedList<int>(); //LinkList 구현

		public void Initialize()
		{
			_data3.AddLast(101);
			_data3.AddLast(102);
			MyLinkedListNode<int> node = _data3.AddLast(103);
			_data3.AddLast(104);
			_data3.AddLast(105);

			_data3.Remove(node);
		}
	}
}
