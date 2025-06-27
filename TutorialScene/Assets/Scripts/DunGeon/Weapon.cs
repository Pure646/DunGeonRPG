using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D Monster)
    {
        // Weapon 안에 있는 Collider2D에 몬스터 Layer가 있다면
        if(Monster.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Debug.Log("Monster");
        }
    }
}
