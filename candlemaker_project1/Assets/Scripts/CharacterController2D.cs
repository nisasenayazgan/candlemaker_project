using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // örnek: sağ veya sol ok tuşuna basılı ise yürüsün
        bool walking = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow);

        anim.SetBool("isWalking", walking);
    }
}
