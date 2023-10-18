using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、移動する（重力対応版）
public class OnKeyPress_MoveGravity : MonoBehaviour {
	public AudioClip se;
	public float speed = 3; // スピード：Inspectorで指定
	public float jumppower = 10;  // ジャンプ力：Inspectorで指定
	float jumpAttackPower = 1;
	bool waitFlag = false;

	float vx = 0;
	bool leftFlag = false; // 左向きかどうか
	bool pushFlag = false; // スペースキーを押しっぱなしかどうか
	bool jumpFlag = false; // ジャンプ状態かどうか
	bool groundFlag = false; // 足が何かに触れているかどうか
	Rigidbody2D rbody;

	void Start () { // 最初に行う
		// 衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void Update () { // ずっと行う
		vx = 0;
		if (Input.GetKey("right")) { // もし、右キーが押されたら
			vx = speed; // 右に進む移動量を入れる
			leftFlag = false;
		}
		if (Input.GetKey("left")) { // もし、左キーが押されたら
			vx = -speed; // 左に進む移動量を入れる
			leftFlag = true;
		}
		// もし、スペースキーが押されたとき、足が何かに触れていたら
		if (Input.GetKey("space") && groundFlag) { 
			if (pushFlag == false) { // 押しっぱなしでなければ
				waitFlag = true; // ジャンプの準備
				pushFlag = true; // 押しっぱなし状態
			}
			jumpAttackPower = jumpAttackPower + 0.05f;
			if (jumpAttackPower > jumppower) {
				jumpAttackPower = jumppower;
            }
		} else {
			if (waitFlag == true) {
				waitFlag = false;
				jumpFlag = true;
            }
			pushFlag = false; // 押しっぱなし解除
		}
		if (this.transform.position.x > 9)
		{
			Vector3 pos = this.transform.position;
			pos.x = -5;
			this.transform.position = pos;
		}
		if (this.transform.position.x < -6)
		{
			Vector3 pos = this.transform.position;
			pos.x = 8;
			this.transform.position = pos;
		}
	}
	void FixedUpdate() { // ずっと行う（一定時間ごとに）
						 // 移動する（重力をかけたまま）
		if (groundFlag == false) { 
		rbody.velocity = new Vector2(vx, rbody.velocity.y);
	}
		// 左右に向きを変える
		this.GetComponent<SpriteRenderer>().flipX = leftFlag;
		// もし、ジャンプするとき
		if (jumpFlag) {
			gameObject.GetComponent<AudioSource>().PlayOneShot(se);
			jumpFlag = false;
			rbody.AddForce(new Vector2(0, jumpAttackPower), ForceMode2D.Impulse);
			jumpAttackPower = 1;

		}
		if (this.transform.position.x < -5)
		{
			Vector3 pos = this.transform.position;
			pos.x = 8;
			this.transform.position = pos;
		}
		
		if (this.transform.position.x > 8)
		{
			Vector3 pos = this.transform.position;
			pos.x = -5;
			this.transform.position = pos;
		}
		
	}
	void OnTriggerStay2D(Collider2D collision) { // 足が何かに触れたら
		groundFlag = true;
	}
	void OnTriggerExit2D(Collider2D collision) { // 足に何も触れなかったら
		groundFlag = false;
	}


}