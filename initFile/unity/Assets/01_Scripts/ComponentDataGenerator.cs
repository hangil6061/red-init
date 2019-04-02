using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ComponentDataGenerator
{
    public static ComponentData CreateComponent(Component comp)
    {
        if (comp is SpriteRenderer)
        {
            return new SpriteData(comp as SpriteRenderer);
        }
        else if( comp is Script )
        {
            return new ScriptData(comp as Script);
        }
        else if (comp is Image)
        {
            return new SpriteData(comp as Image);
        }

        return null;
    }
}
