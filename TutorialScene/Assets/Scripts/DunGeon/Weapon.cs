using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D Monster)
    {
        // Weapon �ȿ� �ִ� Collider2D�� ���� Layer�� �ִٸ�
        if(Monster.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Debug.Log("Monster");
        }
    }
}
