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
    #region Private Fields

    [SerializeField] private Operation operation;
    [SerializeField] private int value;
    [SerializeField] private TextMeshPro gateTxt;
   [SerializeField] private GameObject gate;
   
    #endregion


    #region Unity Methods
 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (operation == Operation.Add)
            { 
                Add(other.transform,value);
            }
            else if (operation == Operation.Multiply)
            {
                Character character = other.GetComponent<Character>();
                int count=Multiply(character);
                print(count);
                Add(character.transform,count);
               
            }
            gate.SetActive(false);
        }
    }

    private void Start()
    {
         SetGateText();
    }

    void SetGateText()
    {
        switch (operation)
        {
            case Operation.Add:
                gateTxt.text = "+" + value;
                break;
            case Operation.Multiply:
                gateTxt.text = "X" + value;
                break;
        }
    }
    void Add(Transform player,int count)
    {
        for (int i = 0; i < count; i++)
            ObjectPool.Instance.GetPooledObject((int)PoolTypes.CharacterTypes.MainPlayer, player);
         
    }

    int Multiply(Character character)
    {
        int spawnCount = (value - 1) * character.characterUnits.Count;
        return spawnCount;

    }

    #endregion
}
