using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevel : MonoBehaviour
{
    [SerializeField] private Material _targetMaterial;

    [SerializeField]
    private float _speed = 0.01f;

    private float _snowDepth = 0;

    public Material[] TargetMaterials;
    
    
    void Update()
    {
        if (TargetMaterials.Length == 0)
        {
            return;
        }

        _snowDepth += Time.deltaTime * _speed;

        for (int i = 0; i < TargetMaterials.Length; i++)
        {
            TargetMaterials[i].SetFloat("_Snow", 1 - _snowDepth);
        }
    }
}