using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : DefaultController
{
    /* 
     * DefaultController contains
     * 
     * [Rigidbody] rb
     * [Animator] anim
     * 
     * [float] moveSpeed
     */

    protected float horizontalInput;
    protected bool isAttacking = false;

    private enum State
    {
        Idle,
        Walk,
        Attack,
        Guard
    }
    private State currentState = State.Idle;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

        PlayerInput();
        
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Movement();
        AnimationSet();
    }


    // 애니메이션 상태 설정 함수 (Update에서 호출)
    private void AnimationSet()
    {
        if (isAttacking) return;

        anim.SetFloat("xSpeed", Mathf.InverseLerp(-1f, 1f, horizontalInput));
    }

    // 플레이어의 움직임 함수 (FixedUpdate에서 호출)
    private void Movement()
    {
        //움직임 제어
        if(currentState == State.Attack || currentState == State.Guard)
        {
            return;
        }

        rb.MovePosition(rb.position + Vector3.right * horizontalInput * moveSpeed * Time.fixedDeltaTime);
    }

    // 플레이어 입력 처리 함수 (Update에서 호출)
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(!isAttacking && Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(PlayerAttack("Kick"));
        }
        if (!isAttacking && Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(PlayerAttack("Punch"));
        }
    }

    // 플레이어 공격 코루틴
    IEnumerator PlayerAttack(string attackType)
    {
        currentState = State.Attack;
        isAttacking = true;

        anim.SetTrigger(attackType);

        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animInfo.length);

        currentState = State.Idle;
        isAttacking = false;
    }

    
}
