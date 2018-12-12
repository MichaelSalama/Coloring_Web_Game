using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "Variables/IntVariable", order = 2)]
public class IntVariable : ScriptableObject
{
    public int value;

    public void SetValue(int val)
    {
        value = val;
    }
}