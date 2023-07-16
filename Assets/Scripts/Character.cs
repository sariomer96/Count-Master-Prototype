using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 2f;
    public List<CharacterUnit> characterUnits = new List<CharacterUnit>();
    [SerializeField] protected TextMeshPro countTxt;
     private event Action OnCountChanged;
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
            FightStatus();
            
        }
    }

    private int count=0;
   
   [SerializeField] public PoolTypes.CharacterTypes characterType;

   public void RemoveUnit(CharacterUnit unit)
   {
         
       Count--;
       characterUnits.Remove(unit);
    
       OnCountChanged?.Invoke();
   }

   private void OnEnable()
   {
       OnCountChanged += SetCountText;
   }

   private void OnDisable()
   {
       if(!this.gameObject.scene.isLoaded) return;
       OnCountChanged -= SetCountText;
   }

   public void AddUnit(CharacterUnit unit)
   {
       Count++;
       characterUnits.Add(unit);
       
       OnCountChanged?.Invoke();
   }

   protected void SetCountText()
   {
      
       DoText.SetText(countTxt, characterUnits.Count);
     
   }


   public abstract void FightStatus();
    
  public void SetTargetNavAgentAllUnit(Transform target)
   {
       for (int i = 0; i < characterUnits.Count; i++)
       {
           characterUnits[i].destination = target;
       }
   }
   
    
}
