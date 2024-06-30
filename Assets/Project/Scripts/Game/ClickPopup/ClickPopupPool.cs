using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class ClickPopupPool : MonoBehaviour
{
    [SerializeField] private Transform contentActive;
    [SerializeField] private Transform contentNotActive;
    [SerializeField] private int size;
    
    [SerializeField] private ClickPopupView clickPopupViewPrefab;

    private Queue<ClickPopupView> objectQueue = new();

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            CreateNewObject();
        }
    }
    
    private void CreateNewObject()
    {
        if (!clickPopupViewPrefab)
        {
            Debug.LogError("Not have prefab");
            return;
        }
        var newObject = Instantiate(clickPopupViewPrefab, contentNotActive);
        objectQueue.Enqueue(newObject);
    }

    public ClickPopupView Get()
    {
        if (objectQueue.Count == 0)
        {
            CreateNewObject();
        }
        
        var getObject = objectQueue.Dequeue();
        getObject.transform.SetParent(contentActive);

        return getObject;
    }

    public void Release(ClickPopupView clickPopupObject)
    {
        objectQueue.Enqueue(clickPopupObject);
        clickPopupObject.transform.SetParent(contentNotActive);
    }
}