using UnityEngine;

public class GunModel: MonoBehaviour
{
    public Transform ModelPointing;


    
    void Update()
    {   
        ModelPointing.rotation = GunHand.OffsetedRotation;
        ModelPointing.position = GunHand.OffsetedPosition;
        
    }
}
