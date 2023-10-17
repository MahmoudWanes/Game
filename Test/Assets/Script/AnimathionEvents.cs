using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimathionEvents : MonoBehaviour
{
    public CharcterMovment charMove;

    public void playerattack()
    {
        Debug.Log("Player Attacked !");
        charMove.DoAttack();
    }
    public void PlayerDamage()
    {
        transform.GetComponentInParent<EnemyCollidar>().DamagePlayer();
    }
    public void Movesound()
    {
        LevelManger.instance.PlaySound(LevelManger.instance.LevelSounds[0], LevelManger.instance.Player.position);
    }

}
