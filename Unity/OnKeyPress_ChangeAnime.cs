using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、アニメーションを切り換える
public class OnKeyPress_ChangeAnime : MonoBehaviour
{

	public string upAnime = "";     // 上向き：Inspectorで指定
	public string downAnime = "";   // 下向き：Inspectorで指定


	string nowMode = "";
	string oldMode = "";

	void Start()
	{ // 最初に行う
		nowMode = downAnime;
		oldMode = "";
	}

	void Update()
	{ // ずっと行う

		if (Input.GetKey("space"))
		{

			nowMode = upAnime;


		}
		else {
			nowMode = downAnime;
		}
	}




	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）
	  // もし違うキーが押されたら
		if (nowMode != oldMode)
		{
			oldMode = nowMode;
			// アニメを切り換える
			Animator animator = this.GetComponent<Animator>();
			animator.Play(nowMode);
		}
	}
}