using UnityEngine;
using TMPro;
public class Week10_UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text gameClearText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text enemyHpText;
    [SerializeField] TMP_Text hpText;
    [SerializeField] MainHealth hp;
    [SerializeField] EnemyHealth eHp;
    static int score = 0;
    static Week10_UIManager instance;
    void Awake() { instance = this; }
    void Start()
    {
        score = 0;
        gameOverText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }
    void Update()
    {
        UpdateEhpText();
        UpdateHPText();
        if (hp.currentHp <= 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
        else gameOverText.gameObject.SetActive(false);
        if(eHp.currentHp <= 0)
        {
            gameClearText.gameObject.SetActive(true);
        }
        else gameClearText.gameObject.SetActive(false);
    }
    // 他スクリプトから呼ぶ：Week10_UIManager.AddScore(100);
    void UpdateEhpText()
    {
        if (enemyHpText != null) enemyHpText.text = "EnemyHP: " + eHp.currentHp.ToString();
    }
    void UpdateHPText()
    {
        if (hpText != null) hpText.text = "HP: " + hp.currentHp.ToString();
    }
}