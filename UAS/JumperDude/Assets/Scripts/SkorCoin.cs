using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorCoin : MonoBehaviour {
	
	public static int hitungKoin;
	Text hitungKoinText;
	
    void Start() {
		hitungKoin = 0;
		hitungKoinText = GetComponent<Text> ();
        
    }

    void Update() {
		hitungKoinText.text = hitungKoin.ToString();
        
    }
}
