using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI suAnkiPara, zarMaxDeger, cooldownPanel, diceValue, additionalCost;

    public int maxDeger;
    public int _para;
    public float cooldown;
    public int _additionalCost;

    private void Start()
    {
        maxDeger = 6;
        cooldown = 0;
        _additionalCost = 10;
    }

    private void Update()
    {
        zarMaxDeger.text = $"Zar max deðer: {maxDeger}";
        cooldownPanel.text = $"Cooldown: {cooldown.ToString("0.0")}f";
        suAnkiPara.text = $"Þu anki para: {_para}";
        additionalCost.text = $"{_additionalCost}$";

        additionalCost.color = _additionalCost > _para ? new Color32(135, 54, 54, 255) : new Color32(60, 140, 68, 255);

        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            int _dice = Random.Range(1, maxDeger + 1);
            diceValue.text = _dice.ToString();
            _para += _dice;
            cooldown = .2f;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void MaxDegeriArttir()
    {
        if (_para >= _additionalCost)
        {
            maxDeger++;
            _para -= _additionalCost;
            _additionalCost *= 2;
        }
    }
}
