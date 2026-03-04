using UnityEngine;

public class TPMenu: MonoBehaviour 
{
    public Transform player;
    public Transform spawn;
    public void TP()
    {
        player.position = spawn.position;
    }
}
