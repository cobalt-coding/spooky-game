using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smooth = 2.0f;

    public GameObject player;

    void Update()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smooth, smooth * sensitivity));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1.0f / smooth);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1.0f / smooth);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

        if (Input.GetAxis("Vertical") != 0)
            transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.fixedTime * 15) / 10 + player.transform.position.y+0.8f, transform.position.z);
    }


}
