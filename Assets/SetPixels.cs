using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPixels : MonoBehaviour
{
    // This script will tint texture's mip levels in different colors
    // (1st level red, 2nd green, 3rd blue). You can use it to see
    // which mip levels are actually used and how.

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        // duplicate the original texture and assign to the material
        Texture2D texture = (Texture2D)Instantiate(rend.material.mainTexture);
        rend.material.mainTexture = texture;

        // colors used to tint the first 3 mip levels
        var colors = new Color32[3];
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        var mipCount = Mathf.Min(3, texture.mipmapCount);

        // tint each mip level
        for (var mip = 0; mip < mipCount; ++mip)
        {
            var cols = texture.GetPixels32(mip);
            for (var i = 0; i < cols.Length; ++i)
            {
                cols[i] = Color32.Lerp(cols[i], colors[mip], 0.33f);
            }
            texture.SetPixels32(cols, mip);
        }

        // actually apply all SetPixels32, don't recalculate mip levels
        texture.Apply(false);
    }
}