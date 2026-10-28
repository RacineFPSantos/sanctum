using Santum;
using UnityEngine;


/*
Esse script é focado em Mobile para que a camera possa girar ao redor da camera com controles mais simples. 
Nas laterais da tela ele vai girar de acordo com a lateral que o dedo estiver.

outro ponto é que isso não funciona para PRIMEIRA PESSOA.
*/

public class GameCamera : MonoBehaviour
{
    private const float SCREEN_SIDE_BUTTONS = 50.0f;

    private Vector3 offset = new Vector3(0, 10, 20);
    private float currentX = 0.0f;
    private float sensivity = 0.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x < SCREEN_SIDE_BUTTONS)
            {
                currentX -= Time.deltaTime * sensivity;
            }
            else if (mousePos.x > Screen.width - SCREEN_SIDE_BUTTONS)
            {
                currentX += Time.deltaTime * sensivity;
            }
        }

        Vector3 dir = offset;
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        transform.position = rotation * dir;
        transform.LookAt(Vector3.up * (TheTower.Instance.GetTowerHeight() / 2));
    }
}
