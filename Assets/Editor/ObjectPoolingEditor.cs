using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPool))]
public class ObjectPoolingEditor :Editor
{
    
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        ObjectPool objectPool = (ObjectPool)target;
     base.OnInspectorGUI();    
        if (GUILayout.Button("Create Pool"))
        {
            
            objectPool.InitPool();
        }

    }
}
