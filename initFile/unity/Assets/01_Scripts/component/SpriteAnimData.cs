using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteAnimData : ComponentData
{
    public string[] sprites;
    public SpriteAnimClip[] clips;

    public SpriteAnimData(SpriteAnim anim) : base(anim, "spriteAnimation")
    {
        sprites = new string[anim.sprites.Length];
        for( int i = 0; i < sprites.Length; i++ )
        {
            sprites[i] = anim.sprites[i].name;
        }
        clips = anim.clips;
    }
}
