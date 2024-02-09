using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/character")]
public class CharacterData : ScriptableObject
{
    public int Damages;
    public float ShotSpeed;
    public float ShotDelay;
    public int MaxHP;
    public int Level;
}
