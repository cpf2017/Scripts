using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    private PlayerMove move;
    public Animation ani;
	// Use this for initialization
	void Start () {

        move = this.GetComponent<PlayerMove>();
        ani = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (move.state == PlayerState.Moving)
        {
            PlayAnim("Run");
        }
        else if (move.state == PlayerState.Idle)
        {
            PlayAnim("Idle");
        }
	}

    void PlayAnim(string animName)
    {
        ani.CrossFade(animName);
    }
}
