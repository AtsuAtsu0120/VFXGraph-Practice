using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntaractiveObject : MonoBehaviour
{
    public virtual void OnHitRay()
    {
        Debug.Log("Ray hit!");
    }
    public virtual void OnFailRay()
    {
        Debug.Log("Ray fail.");
    }
    public virtual void OnPressActionButton()
    {
        Debug.Log("Press ActionButton!");
    }
}
