using UnityEngine;
using TMPro;
public class Week10_UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text hpText;
    static int score = 0;
    static int hp = 5;
    static Week10_UIManager instance;
    void Awake() { instance = this; }
    void Start()
    {
        score = 0;
        hp = 5;
        UpdateScoreText();
        UpdateHPText();
    }
    // 他スクリプトから呼ぶ：Week10_UIManager.AddScore(100);
    public static void AddScore(int amount)
    {
        score += amount;
        if (instance != null) instance.UpdateScoreText();
    }
    public static void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp < 0) hp = 0;
        if (instance != null) instance.UpdateHPText();
    }
    void UpdateScoreText()
    {
        if (scoreText != null) scoreText.text = "Score: " + score.ToString();
    }
    void UpdateHPText()
    {
        if (hpText != null) hpText.text = "HP: " + hp.ToString();
    }
}