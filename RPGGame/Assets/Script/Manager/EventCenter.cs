using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter : MonoBehaviour
{
    public static event Action<Enemy> onEnemyDied;

// enemy中触发enemydied，通过此函数触发onenemydied，触发所有加入onenemydied的函数
    public static void EnemyDied(Enemy enemy){
        onEnemyDied?.Invoke(enemy);
    }
}
