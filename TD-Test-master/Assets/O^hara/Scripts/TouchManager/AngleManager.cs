using UnityEngine;
using System.Collections;

public class AngleManager : MonoBehaviour {

    public enum Angle_Value
    {
        NONE = 0,
        UP = 1,
        DOWN = 2,
        RIGHT = 3,
        LEFT = 4,
        UPPER_RIGHT = 5,
        LOWER_RIGHT = 6,
        UPPER_LEFT = 7,
        LOWER_LEFT = 8,
    }
    private Angle_Value angleValue;

    private float directionX;
    private float directionY;
    private float radian;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void  AzimuthUpdate()
    {
        if (angleValue != Angle_Value.NONE)
        {
            angleValue = Angle_Value.NONE;
           // Debug.Log("NONE");
        }
    }

    float Direction(float start_pos,float end_pos)
    {
        return end_pos - start_pos;
    }

    public void Angle_calculation(Vector3 start_pos,Vector3 end_pos)
    {
        directionX = Direction(start_pos.x, end_pos.x);
        directionY = Direction(start_pos.y, end_pos.y);
        radian = Mathf.Atan2(directionY, directionX) * Mathf.Rad2Deg;

        if (radian <= 22.5 && radian >= -22.5)
        {
            angleValue = Angle_Value.RIGHT;
        }
        if (radian <= -22.5 && radian >= -67.5)
        {
            angleValue = Angle_Value.LOWER_RIGHT;
        }
        if (radian <= -67.5 && radian >= -112.5)
        {
            angleValue = Angle_Value.DOWN;
        }
        if (radian <= -112.5 && radian >= -157.5)
        {
            angleValue = Angle_Value.LOWER_LEFT;
        }
        if (radian <= -157.5 && radian >= -180 || radian >= 157.5 && radian <= 180)
        {
            angleValue = Angle_Value.LEFT;
        }

        if (radian >= 22.5 && radian <= 67.5)
        {
            angleValue = Angle_Value.UPPER_RIGHT;
        }
        if (radian >= 67.5 && radian <= 112.5)
        {
            angleValue = Angle_Value.UP;
        }
        if (radian >= 112.5 && radian <= 157.5)
        {
            angleValue = Angle_Value.UPPER_LEFT;
        }
    }

    public Angle_Value Angle
    {
        get
        {
            return angleValue;
        }
        set
        {
            angleValue = value;
        }
    }
}
