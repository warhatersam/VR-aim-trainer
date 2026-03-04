using UnityEngine;

[System.Serializable]
public class WeaponGroup
{
    public string groupName;         // optional, just for readability
    public GameObject[] weapons;
}

public class WeaponSelection: MonoBehaviour
{
    public WeaponGroup[] weaponList;
    public string SaveKey = "WeaponIndex";
    public int defaultIndex = 0;

    public void Start()
    {
        int saved = PlayerPrefs.GetInt(SaveKey, defaultIndex );
        Apply(saved);
    }

    public void Select(int index)
    {
        Apply(index);
        PlayerPrefs.SetInt(SaveKey, index);
        PlayerPrefs.Save();
    }
    public void Apply(int index)
    {
        for (int i = 0; i < weaponList.Length; i++)
        {
            if (weaponList[index] != null)
            {
                for (int j = 0; j < weaponList[i].weapons.Length; j ++)
                {
                    weaponList[i].weapons[j].SetActive(i == index);
                }
            }
        }
    }

}
