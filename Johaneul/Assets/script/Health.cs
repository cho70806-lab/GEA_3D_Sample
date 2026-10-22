using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public GameObject hitEffect;   // HitEffect Prefab

    public static int killCount;
    public int maxHp = 3;
    public int currentHp;
    public Slider hpSlider;
    public GameObject dropPrefab;     // 적만 연결
    public float dropChance = 0.3f;   // 30%

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        UpdateBar();
    }

    void Start()
    {
        currentHp = maxHp;
        UpdateBar();
    }

    public float invincibleTime = 0f;   // 플레이어는 0.5
    float lastHitTime = -999f;

    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;
        if (Time.time < lastHitTime + invincibleTime) return;
        lastHitTime = Time.time;

        currentHp -= damage;
        Debug.Log(name + " HP: " + currentHp);
        UpdateBar();
        Vector3 hitPos = transform.position + Vector3.up;
        if (hitEffect != null)
            Instantiate(hitEffect, hitPos, Quaternion.identity);

        if (currentHp <= 0) Die();
        else Blink();
    }
    void Blink()
    {
        SetVisible(false);
        Invoke(nameof(ShowAgain), 0.1f);
    }

    void ShowAgain()
    {
        SetVisible(true);
    }

    void SetVisible(bool on)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = on;
    }



    void UpdateBar()
    {
        if (hpSlider != null)
            hpSlider.value = (float)currentHp / maxHp;
    }

    void Die()
    {
        if (CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }

        else
        {
            killCount++;
            if (dropPrefab != null && Random.value < dropChance)
            {
                Vector3 pos = transform.position + Vector3.up * 0.5f;
                Instantiate(dropPrefab, pos, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

}
