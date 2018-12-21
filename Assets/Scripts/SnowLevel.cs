using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowLevel : MonoBehaviour
{
    [SerializeField] private Material _targetMaterial;

    [SerializeField]
    private float _speed = 0.01f;

    private float _snowDepth = 0;

    public Material TargetMaterial => _targetMaterial;
    
    
    void Update()
    {
        if (!TargetMaterial)
        {
            return;
        }

        _snowDepth += Time.deltaTime * _speed;

        TargetMaterial.SetFloat("_Snow", 1 - _snowDepth);
    }
}