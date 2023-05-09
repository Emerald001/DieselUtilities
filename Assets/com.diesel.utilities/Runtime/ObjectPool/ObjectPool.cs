using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipoolable { 
    bool Active { get; set; }
    void Init();
    void OnEnableObject();
    void OnDisableObject();
}

public class ObjectPool<T> where T : Ipoolable
{
    private readonly List<T> activePool = new();
    private readonly List<T> inactivePool = new();

    private T AddNewItemToPool() {
        T instance = (T)Activator.CreateInstance(typeof(T));
        instance.Init();

        inactivePool.Add(instance);
        return instance;
    }

    public T GetObjectFromPool() {
        if(inactivePool.Count > 0) 
            return ActivateItem(inactivePool[0]);

        return ActivateItem(AddNewItemToPool());
    }

    public T ActivateItem(T item) {
        item.OnEnableObject();
        item.Active = true;

        if (inactivePool.Contains(item)) 
            inactivePool.Remove(item);

        activePool.Add(item);
        return item;
    }

    public void ReturnObjectToInactivePool(T item) {
        if (activePool.Contains(item)) 
            activePool.Remove(item);

        item.OnDisableObject();
        item.Active = false;
        inactivePool.Add(item);
    }
}