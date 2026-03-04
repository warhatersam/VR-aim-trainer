using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class GunHand: MonoBehaviour
{
    public Transform HandPointing;
    public LayerMask TargetMask;
    public InputActionReference input;
    private float Range = 9999f;
    public float Damage = 10f;
    private float firingrate = 12f;
    public float NextTimeToFire = 0; 
    public static UnityEvent Shot = new UnityEvent();
    public static UnityEvent Hit = new UnityEvent();
    public AudioSource source;
    public AudioClip shotsound;
    public AudioClip hitsound;
    private float RifleZOffset = 0.053f;
    private float PistolZOffset = 0.03f;
    public static float BarrelOffset = 0f;

    public static Quaternion OffsetedRotation;
    public static Vector3 OffsetedPosition;
    public static Vector3 BarrelPosition;
    public string WeaponSavekey = "WeaponIndex";
    public string FireModekey = "FireMode";

    void OnEnable() => input.action.Enable();
    void OnDisable() => input.action.Disable();

    void Start()
    {
        int SavedIndex = PlayerPrefs.GetInt(WeaponSavekey, 0);
        Select(SavedIndex);
        int FireMode = PlayerPrefs.GetInt(FireModekey,0);
    }
    public void Select(int index)
    {
        if (index == 0)
        {
            BarrelOffset = RifleZOffset;
        }
        else if (index == 1)
        {
            BarrelOffset = PistolZOffset;
        }
        PlayerPrefs.SetInt(WeaponSavekey, index);

    }
    public void SelectFireMode(int index)
    {
        PlayerPrefs.SetInt(FireModekey, index);
    }
    void Update()
    {   
        float PitchOffset = Menu.PitchOffset;
        float YawOffset   = Menu.YawOffset;
        float RollOffset  = Menu.RollOffset;
        float xOffset = PositionAdjustment.xOffset;
        float yOffset = PositionAdjustment.yOffset;
        float zOffset = PositionAdjustment.zOffset;
        Vector3 PosOffset = new Vector3(xOffset, yOffset, zOffset);
        
        Quaternion OriginalPointing = HandPointing.rotation;
        Quaternion Offset = Quaternion.Euler(PitchOffset, YawOffset, RollOffset);
        OffsetedRotation = OriginalPointing * Offset;
        OffsetedPosition = HandPointing.position + OffsetedRotation * PosOffset;
        BarrelPosition = HandPointing.position + OffsetedRotation * (PosOffset + Vector3.up * BarrelOffset);   
        if (PlayerPrefs.GetInt(FireModekey) == 0)
        {
            
            Semiauto();
        }
        
        if (PlayerPrefs.GetInt(FireModekey) == 1) 
        {
            Fullauto();
        }
    }
    void Semiauto()
    {
        if (input.action.WasPressedThisFrame()) // single shot per press
        {
            Shoot();
            Shot.Invoke();
        }
    }
    void Fullauto()
    {
        if (input.action.IsPressed())
            {   
                if (Time.time > NextTimeToFire)
            {
                Shoot();
                NextTimeToFire = Time.time + 1 / firingrate;
                Shot.Invoke();
            }
                
            }
    }
    void Shoot()
    {   
        source.PlayOneShot(shotsound, 0.5f);
        Vector3 OffsetedDir = OffsetedRotation * Vector3.forward;
        Ray ray = new Ray(BarrelPosition, OffsetedDir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range, TargetMask) )
        {
            Hit.Invoke();
            source.PlayOneShot(hitsound, 0.8f);
            Health h = hit.collider.GetComponentInParent<Health>();
            if (h != null)
            {
                h.TakeDamage(Damage);
            }
        }
    }
}
