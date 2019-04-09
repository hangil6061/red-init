using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteAnimClip
{
    public string name;
    public int[] spriteIndexArr;
    public float interval;
}

[RequireComponent(typeof(Image))]
public class SpriteAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteAnimClip[] clips;

    public string defaultAniName = "";
    private float time = 0;
    private int index = 0;
    private SpriteAnimClip anim;
    private Image img;


    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Start()
    {
        time = 0;
        index = 0;
        for ( int i = 0; i < clips.Length; i++ )
        {
            if( clips[i].name == defaultAniName )
            {
                anim = clips[i];
                img.sprite = sprites[clips[i].spriteIndexArr[0]];
                break;
            }
        }        
    }

    private void Update()
    {
        if (anim == null) return;
        time += Time.deltaTime;

        if( time >= anim.interval )
        {
            time = 0;
            index = (index + 1) % anim.spriteIndexArr.Length;
            img.sprite = sprites[anim.spriteIndexArr[index]];
        }
    }



}
