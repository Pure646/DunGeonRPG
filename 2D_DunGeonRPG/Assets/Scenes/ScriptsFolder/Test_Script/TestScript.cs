using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class TestScript : MonoBehaviour
{
    [ContextMenu("Reset Health")]
    public void ResetHealth()
    {
        Debug.Log("Health Reset");
    }

    private float Number = 0;
    private bool OnResetNumber = true;
    [Tooltip("안녕하세요. 이것은 Tooltip 입니다.")][SerializeField] private float Hello = 5f;

    private void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
    }
    private void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
    }
    private void EditorUpdate()
    {
        if(Number < 100)
        {
            Debug.Log($" ExecuteInEditMode : {Number}");
            Number++;
            OnResetNumber = true;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnResetNumber = true;
            Number = 0;
        }
    }
}
