using UnityEngine;

[CreateAssetMenu(fileName ="NewColorVariable",menuName ="Variables/Color",order =1)]
public class ColorVariable : ScriptableObject
{
    [HideInInspector]
    public Color32 value;

}
