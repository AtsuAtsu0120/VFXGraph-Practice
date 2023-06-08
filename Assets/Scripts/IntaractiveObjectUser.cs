using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class IntaractiveObjectUser : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private Camera characterCamera;

    [Header("Settings")]
    [SerializeField] private int rayLayer;
    [SerializeField] private float rayDistance;


    private int mask;
    private Camera rayCam;
    private RaycastHit hitObj;
    private IntaractiveObject component;
    private bool isHit;
    private bool isHitEventIvoked;

    private void Awake()
    {
        //�O�����Z�q
        rayCam = characterCamera == null ? Camera.main : characterCamera;
        //�V�t�g���Z�q
        mask = 1 << rayLayer;
        Debug.Log(mask);
    }
    private void Update()
    {
        isHit = Physics.Raycast(rayCam.transform.position, rayCam.transform.forward.normalized, out hitObj, rayDistance, mask);
        if(isHit)
        {
            component = hitObj.transform.GetComponent<IntaractiveObject>();
            component.OnHitRay();
            isHitEventIvoked = true;
        }
        else if(isHitEventIvoked)
        {
            component.OnFailRay();
            isHitEventIvoked = false;
        }
    }
    public void OnPressActionButton()
    {
        if(isHit)
        {
            component.OnPressActionButton();
            isHitEventIvoked = false;
        }
    }
}
