using UnityEngine;
using UnityEngine.VFX;

public class GateVFX : IntaractiveObject
{
    [SerializeField] private VisualEffect vfx;
    public override void OnHitRay()
    {
        vfx.SetBool("OnHit", true);
    }
    public override void OnFailRay()
    {
        Debug.Log("Fail");
        vfx.SetBool("OnHit", false);
        vfx.SetBool("isActioned", false);
    }
    public override void OnPressActionButton()
    {
        Debug.Log("Actioned!");
        vfx.SetBool("isActioned", true);
    }
}
