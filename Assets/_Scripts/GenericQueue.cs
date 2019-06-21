using System.Collections.Generic;
using UnityEngine;

public class GenericQueue<T> : MonoBehaviour
{
    private List<T> queue = new List<T>(); // Generic queue list

    /// <summary>
    /// This function adds a new generic to the queue
    /// </summary>
    /// <param name="genericObject"></param>
    public void QueueNewGeneric(T genericObject)
    {
        queue.Add(genericObject);
    }

    /// <summary>
    /// This function returns a generic from the queue, based on the index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public dynamic GetGenericFromQueue(int index)
    {
        T generic = queue[index];
        return generic;
    }

    /// <summary>
    /// This function removes a generic from the queue, based on the index
    /// </summary>
    /// <param name="index"></param>
    public void RemoveFromQueue(int index)
    {
        queue.RemoveAt(index);
    }
}
