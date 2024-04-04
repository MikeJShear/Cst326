using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    public int startLives = 3;

    public static int rounds;

    void Start()
    {
        Instance = this;
        Money = startMoney;
        Lives = startLives;

        rounds = 0;
    }

    
}
