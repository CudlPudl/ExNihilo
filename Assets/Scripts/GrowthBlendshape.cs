using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthBlendshape : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer _renderer;
    private int _blendShapeCount;

    // DEBUG
    [Range(0, 1), SerializeField]
    private float _blend;


    [SerializeField]
    private List<float> _values = new List<float>();

    private void Awake()
    {
        _blendShapeCount = _renderer.sharedMesh.blendShapeCount;
    }

    public void SetBlendValue(float value)
    {
        _values.Clear();
        var blendValue = value * _blendShapeCount;
        for (var i = 0; i < _blendShapeCount; ++i)
        {
            var curValue = Mathf.Clamp01(1 - Mathf.Abs((i + 1) - blendValue)) * 100;
            _renderer.SetBlendShapeWeight(i, curValue);
            _values.Add(curValue);
        }
    }
}
