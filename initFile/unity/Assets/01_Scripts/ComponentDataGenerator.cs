using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public static class ComponentDataGenerator
{
    public static ComponentData CreateComponent(Component comp)
    {
        if (comp is SpriteRenderer)
        {
            return new SpriteData(comp as SpriteRenderer);
        }
        else if (comp is Script)
        {
            return new ScriptData(comp as Script);
        }
        else if (comp is Image)
        {
            switch((comp as Image).type)
            {
                case Image.Type.Filled:
                    return new GaugeData(comp as Image);
                case Image.Type.Sliced:
                    return new NineSliceData(comp as Image);
                case Image.Type.Tiled:
                    return new TiledSpriteData(comp as Image);
            }          
            return new SpriteData(comp as Image);
        }
        else if (comp is Text)
        {
            if( comp.GetComponent<MultiStyleText>() )
            {
                return new MultiStyleTextData(comp as Text);
            }
            else
            {
                return new TextData(comp as Text);
            }          
        }
        else if( comp is Button )
        {
            return new ButtonData(comp as Button);
        }
        else if (comp is SkeletonGraphic)
        {
            return new SpineData(comp as SkeletonGraphic);
        }
        else if (comp is BoxCollider2D)
        {
            return new BoxCollider2DData(comp as BoxCollider2D);
        }
        else if (comp is CircleCollider2D)
        {
            return new CircleColliderData(comp as CircleCollider2D);
        }
        else if (comp is SpriteAnim)
        {
            return new SpriteAnimData(comp as SpriteAnim);
        }
        else if (comp is InputText)
        {
            return new InputTextData(comp as InputText);
        }
        else if (comp is Scroll)
        {
            return new ScrollData(comp as Scroll);
        }
        else if (comp is ToggleButton)
        {
            return new ToggleButtonData(comp as ToggleButton);
        }
        else if (comp is PaintArea)
        {
            return new PaintAreaData(comp as PaintArea);
        }
        else if( comp is ButtonEvent )
        {
            return new ButtonEventData(comp as ButtonEvent);
        }

        return null;
    }
}
