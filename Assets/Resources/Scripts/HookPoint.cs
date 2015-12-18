using UnityEngine;
using System.Collections;

public class HookPoint {
    public bool isActive;
    public Vector3 position;

	public HookPoint() {
        isActive = false;
        position = Vector3.zero;
    }
}
