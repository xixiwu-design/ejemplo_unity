using UnityEngine;

public class Meteorit : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //Translete和position的区别是Translete是相对移动，position是绝对移动
        //参数的
        transform.Translate(Vector3.back * vel * Time.deltaTime);

        //当陨石的z轴小于-5时，销毁陨石
        if (transform.position.z < ValorsGlobales.limiteZNegativo)
        {
            Destroy(gameObject);
        }
    }
}
