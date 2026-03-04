using UnityEngine;

public class TP0: MonoBehaviour 
{
    public Transform player;
    public Transform spawn;
    public void TP()
    {
        player.position = spawn.position;
    }
}
