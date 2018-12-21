using UnityEngine;

[ExecuteInEditMode]
public class SnowCamera : MonoBehaviour
{
    [SerializeField] private Material _effectMaterial;

    public Material EffectMaterial => _effectMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (EffectMaterial == null)
        {
            return;
        }

        Graphics.Blit(src, dst, EffectMaterial);
    }
}