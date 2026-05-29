using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	void OnCollisionEnter () {
        BreakoutGame.SP.HitBlock();
        Destroy(gameObject);
	}
}
