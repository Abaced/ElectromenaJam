using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Attack", menuName = "Battle/Attack", order = 1)]
public class PlayerAttack : ScriptableObject
{
    public string Name;
    public float Damage;

    public KeyCode Input;

    public Color ColorAttack;
    public Sprite ImgAttack;
}
