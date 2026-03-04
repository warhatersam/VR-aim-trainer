using UnityEngine;

public class line: MonoBehaviour 
{
  
    public LayerMask hitMask;
    LineRenderer lr;
    float length = 999f;
    public Transform HandPointing;
    private Quaternion OffsetedRotation;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.positionCount = 2;

        
    }
    void Update()
    {   
        
        OffsetedRotation = GunHand.OffsetedRotation;

        Vector3 dir = OffsetedRotation * Vector3.forward;
        Vector3 origin = GunHand.BarrelPosition;
        Vector3 end = origin + dir * length;
        // Ray ray = new Ray(Pointing.position, Pointing.forward);
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, length, hitMask)) ;
    
        lr.SetPosition(0, origin);
        lr.SetPosition(1, end);   
    }
}
