using UnityEngine;

/// <summary>
/// Resets every prop in the scene that has a PropResetter.
/// Called from the World Space UI button "Reset Props".
/// </summary>
public class ResetAllProps : MonoBehaviour
{
    public void ResetProps()
    {
        PropResetter[] props = FindObjectsByType<PropResetter>(FindObjectsSortMode.None);
        foreach (PropResetter prop in props)
        {
            prop.ResetToStart();
        }
    }
}
