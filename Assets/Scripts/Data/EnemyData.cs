using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/enemy")]
public class EnemyData : ScriptableObject
{
    public int Damages;
    public float Speed;
    public int MaxHP;
}
