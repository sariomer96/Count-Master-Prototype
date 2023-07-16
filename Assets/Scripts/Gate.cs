using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum Operation
{
    Multiply,
    Add
};

public class Gate : MonoBehaviour
{
    

    [SerializeField] private Operation _operation;
    [SerializeField] private int _count;
    [SerializeField] private TextMeshPro gateTxt;
    [SerializeField] private GameObject gate;
    
    private void Start()
    {
        SetGateText();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (_operation == Operation.Add)
                Add(other.transform,_count);
            
            else if (_operation == Operation.Multiply)
            {
                Colony colony = other.GetComponent<Colony>();
                int count=Multiply(colony);
                
                Add(colony.transform,count);
               
            }
            gate.SetActive(false);
        }
    } 
    void SetGateText()
    {
        switch (_operation)
        {
            case Operation.Add:
                gateTxt.text = "+" + _count;
                break;
            case Operation.Multiply:
                gateTxt.text = "X" + _count;
                break;
        }
    }
    void Add(Transform player,int count)
    {
        for (int i = 0; i < count; i++)
            ObjectPool.Instance.GetPooledObject((int)PoolTypes.CharacterTypes.MainPlayer, player);
         
    }
    int Multiply(Colony colony)
    {
        int spawnCount = (_count - 1) * colony.characterUnits.Count;
        return spawnCount;

    }
}
