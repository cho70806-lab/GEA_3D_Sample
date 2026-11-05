using UnityEngine;

public class RewardCalc : MonoBehaviour
{
    public int playerSeconds = 3725, gold = 1234, members = 4, kills = 7, exPerkill = 35, totalDamage = 250, hit = 20;

    public float expRate = 1.5f;

    [ContextMenu("시간")]

    void playtime()
    {
        int minutes = playerSeconds / 60;
        int hour = minutes / 60;

        Debug.Log(hour + "시간" + (minutes % 60) + "분" + (playerSeconds % 60) + "초");
    }

    
}
