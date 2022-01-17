using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour { 
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag.Equals ("Player")){
			print("Yay Koin!");
			Destroy (gameObject);
			SkorCoin.hitungKoin += 10;
		}
	}

}
