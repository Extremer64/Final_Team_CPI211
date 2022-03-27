using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLStack<T> : LinkedList<T>
{
    //Imitating a stack with a linked list

    public T Pop()
    {
        T first = First.Value;
        RemoveFirst();
        return first;
    }

    public T Peek()
    {
        T first = First.Value;
        return first;
    }

    public void Push(T t)
    {
        AddFirst(t);
    }
}
