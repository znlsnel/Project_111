using UnityEngine;

public static class UtilMaterial
{
    public static void SetShaderProperty(int propertyId, MaterialPropertyBlock propertyBlock, SpriteRenderer sr, Color value)
    {
        if (sr == null)
            return;

        sr.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor(propertyId, value);
        sr.SetPropertyBlock(propertyBlock);
    }
}