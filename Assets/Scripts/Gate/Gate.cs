using System;
using System.Collections;
using System.Collections.Generic;
using Colony;
using ObjectPool;
using TMPro;
using UnityEngine;

namespace Gate
{
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
                    PlayerColonyController.Instance.AddUnit(_count);
            
                else if (_operation == Operation.Multiply)
                {
                    Colony.Colony colony = other.GetComponent<Colony.Colony>();
                    int count=Multiply(colony);
                    PlayerColonyController.Instance.AddUnit(count);
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
      
        int Multiply(Colony.Colony colony)
        {
            int spawnCount = (_count - 1) * colony.characterUnits.Count;
            return spawnCount;

        }
    }
}