using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{ 
    
    [SerializeField] private Camera _camera;
  
 
   private Vector3 _direction;
   private Vector3 _startPos;
   private Vector3 _finishPos;
   [SerializeField] private float _finishSpeed;

    
    
    public  Vector3 GetDirection()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        
        if (Input.GetMouseButtonDown(0))
        {
           
            _startPos = _camera.ScreenToViewportPoint(new Vector3(mouseX,mouseY, _camera.nearClipPlane)); 
            _finishPos =_startPos;
        }
        if (Input.GetMouseButton(0))
        {
           
            _startPos = _camera.ScreenToViewportPoint(new Vector3(mouseX, mouseY, _camera.nearClipPlane));
 
            _direction = _startPos - _finishPos;
            
            _finishPos = Vector3.Lerp(_finishPos, _startPos, _finishSpeed * Time.deltaTime);
 
            return _direction;
        }
       
        return  Vector3.zero;
    }
 
   
     
       
}
 

