using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMov;
    public void PlayerAttack()
    {
        Debug.Log("Player Attacked!");
        charMov.DoAttack();
    }
    public void PlayerDamage() 
    {
        transform.GetComponentInParent<EnemyController>().DamageManager();


    }
    public void MoveSound()
    {
        LevelManager.instance.PlaySound(LevelManager.instance.LevelSounds[0], LevelManager.instance.player.position);
    }
}
