using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HP_Food_Script : MonoBehaviour
{
    public float food = 100.0f;
    public float hp = 100;
    private float _maxHP;
    private float _maxFood;

    public Text txtFood;
    public Text txtHP;
    public GameObject _quickSlots;

    void Start()
    {
        StartCoroutine(ChangeCharacteristic());

        _maxHP = hp;
        DrawHP();
        _maxFood = food;
        DrawFood();
    }


    void Update()
    {
        if (hp <= 0)
        {
            OnDead();
        }

        if (food > 100)
        {
            food = _maxFood;
        }

        if (hp > 100)
        {
            hp = _maxHP;
        }
    }

    public IEnumerator ChangeCharacteristic()
    {
        var waitTime = new WaitForSeconds(5);

        while (true)
        {
            if (food > 0)
            {
                Hunger();
            }

            if (food <= 0)
            {
                food = 0;
                DealDamage_Hunger();
            }

            yield return waitTime;
        }
    }

    //decoding_

    public void DrawHP()
    {
        txtHP.text = hp.ToString();
    }

    public void OnDead()
    {
        SceneManager.LoadScene(0);
    }

    public void DrawFood()
    {
        txtFood.text = food.ToString();
    }

    public void Hunger()
    {
        food -= 1;
        DrawFood();
    }

    public void DealDamage_Hunger()
    {
        hp -= 5;
        DrawHP();
    }

    public void WhenEat()
    {
        var _quickSlotsParent = _quickSlots.GetComponent<QuickslotInventory>().quickslotParent;
        var _slotID = _quickSlots.GetComponent<QuickslotInventory>().currentQuickslotID;

        food += _quickSlotsParent.GetChild(_slotID).GetComponent<InventorySlot>().item.changeHunger;

        if (food > 100)
        {
            food = 100;
        }

        DrawFood();
    }

    //_decoding
}