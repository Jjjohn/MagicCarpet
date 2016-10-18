/*
 * John Kirchner
 * 
 * PlayerController template taken from ProjectPalmer
 *   playerController class
 *
 */

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text output;
    public GameObject thrownBall;
    public GameObject centerEyeAnchor;
    public float speed;

    private GameObject curBall;
    private float x, y;
    private float minX, maxX, minY, maxY = 0.0f;

    void FixedUpdate()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        if ((Input.GetKeyDown(KeyCode.Space) || x < -10.0f) && !curBall)
        {
            curBall = (GameObject) Instantiate(thrownBall, 
                centerEyeAnchor.transform.position, centerEyeAnchor.transform.rotation);

            curBall.GetComponent<Rigidbody>().AddForce(centerEyeAnchor.transform.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(curBall);
        }

        if (minX > x)
            minX = x;
        if (maxX < x)
            maxX = x;
        if (minY > y)
            minY = y;
        if (maxY < y)
            maxY = y;

        string outText = "x: " + x + "\ny: " + y +
                      "\nminX: " + minX + "\nmaxX: " + maxX +
                      "\nminY: " + minY + "\nmaxY: " + maxY;

        if (curBall)
            outText += "\nTHE BALL IS ALIVE!!!";

        output.text = outText;
    }
}