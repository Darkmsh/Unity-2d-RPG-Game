using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int curentHealth;
    public int maxHealth;

    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP:" + maxHealth + "/" + curentHealth;
    }
    public void ChangeHealth(int amount)
    {
        healthTextAnim.Play("HP_Text");
        curentHealth += amount;
        healthText.text = "HP:" + maxHealth + "/" + curentHealth;

        if (curentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
