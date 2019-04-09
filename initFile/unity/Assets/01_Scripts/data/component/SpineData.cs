using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

[System.Serializable]
public class SpineData : ComponentData
{
    public string key = "";
    public string defaultSkin = "default";
    public string startAnimation = "";
    public bool isStartLoop = true;
    public string color = "FFFFFF";

    public SpineData(SkeletonGraphic spine) : base(spine, "spine")
    {
        defaultSkin = spine.initialSkinName;
        startAnimation = spine.startingAnimation;
        isStartLoop = spine.startingLoop;
        color = Util.ColorToHex( spine.color );
        key = spine.skeletonDataAsset.name;
    }
}
