using UnityEngine;

public class StatPractice : MonoBehaviour
{

    public string playerName;
    public int level = 1;
    public float attack = 1f;
    public bool isBoss = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [ContextMenu("스탯")]

    void ShowStat()
    {
        Debug.Log(playerName);
        Debug.Log(level);
        Debug.Log(attack);
        Debug.Log(isBoss); 
    }
}
