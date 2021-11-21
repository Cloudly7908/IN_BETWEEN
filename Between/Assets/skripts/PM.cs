using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Cam;
    bool Pm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.activeInHierarchy)
        {
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            if (PauseMenu.active == true)
            {
                Cam.GetComponent<PlayerCam>().enabled = false;

            }

        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            if (PauseMenu.active == false)
            {
                Cam.GetComponent<PlayerCam>().enabled = true;

            }
        }
    }
}
