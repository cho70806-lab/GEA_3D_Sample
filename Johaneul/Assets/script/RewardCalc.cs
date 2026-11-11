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

    [ContextMenu("골드")]
    void Gold()
    {
        int leaderBonus = gold % 4;


        Debug.Log("1인당" + (gold / 4) + "G" + "리더 보너스" + leaderBonus + "G");
    }

    [ContextMenu("경험치")]

    void Exp()
    {
        int gibon = kills * exPerkill;
        float exp = gibon * expRate;

        int result = (int)exp;

        int level = result / 100 + 1;
        int remainExp = 100 - result % 100;

        Debug.Log("경험치" + result + "(기본)" + gibon);
        Debug.Log("Lv" + level + "다음 레벨까지" + remainExp);
    }

    [ContextMenu("데미지")]

    void Damage()
    {
        float result = (float)totalDamage / hit;
        Debug.Log("평균 데미지" + result);
    }
}
