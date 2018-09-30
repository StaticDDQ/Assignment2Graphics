using UnityEngine;

public static class GravityControl {

    public static float grav = 9.81f;

	public static void ChangeGravity(int dir)
    {
        switch (dir)
        {
            case 1:
                Physics.gravity = new Vector3(grav, 0, 0);
                break;
            case -1:
                Physics.gravity = new Vector3(-grav, 0, 0);
                break;
            case 2:
                Physics.gravity = new Vector3(0, grav, 0);
                break;
            case -2:
                Physics.gravity = new Vector3(0, -grav, 0);
                break;
            case 3:
                Physics.gravity = new Vector3(0, 0, grav);
                break;
            case -3:
                Physics.gravity = new Vector3(0, 0, -grav);
                break;
        }
    }
}
