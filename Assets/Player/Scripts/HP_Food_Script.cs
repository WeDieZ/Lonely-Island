using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HP_Food_Script : MonoBehaviour
{
    public float food = 100.0f;
    public float hp = 100;
    private float _maxHP;
    private float _maxFood;
    public RectTransform valueRectTransformHP;
    public RectTransform valueRectTransformFood;


    void Start()
    {
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
    }

    void FixedUpdate()
    {
        Hunger();

        if (food <= 0)
        {
            DealDamage_Hunger();
        }
    }

    //decoding_

    public void DrawHP()
    {
        valueRectTransformHP.anchorMax = new Vector2(hp / _maxHP, 1);
    }

    public void DealDamage()
    {
        hp -= 1 * Time.deltaTime;
        DrawHP();
    }

    public void OnDead()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DrawFood()
    {
        valueRectTransformFood.anchorMax = new Vector2(food / _maxFood, 1);
    }

    public void Hunger()
    {
        food -= 0.05f;
        DrawFood();
    }

    public void DealDamage_Hunger()
    {
        hp -= 1 * Time.fixedDeltaTime;
        DrawHP();
    }

    //_decoding
}