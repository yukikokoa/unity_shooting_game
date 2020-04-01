using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 8f;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -8.2f, 8.2f),
            Mathf.Clamp(transform.position.y + dy, -4.5f, 4.5f),
            0f
            );
    }
}
