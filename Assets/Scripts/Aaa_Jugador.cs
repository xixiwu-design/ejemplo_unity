using UnityEngine;
using UnityEngine.InputSystem;

public class Aaa_Jugador : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //f代表float类型，30f代表30.0这个浮点数
        vel = 30f;
    }

    void Update()
    {
        MovimentoJugador();
        ControlarLimitesPantalla();
    }

    void ControlarLimitesPantalla()
    {
        Vector3 posActual = transform.position;

//Mathf.Clamp是一个数学函数，作用是将一个数值限制在一个范围内，
// 如果数值小于最小值，则返回最小值，如果数值大于最大值，则返回最大值，如果数值在范围内，则返回原数值
        posActual.x = Mathf.Clamp(
        posActual.x,
        ValorsGlobales.limiteIzquierdaX,
        ValorsGlobales.limiteDerechaX
        );

        posActual.y = Mathf.Clamp(
            posActual.y,
            ValorsGlobales.limiteAbajoY,
            ValorsGlobales.limiteArribaY
        );

        transform.position = posActual;
    }


    void MovimentoJugador()
    {


        // Update is called once per frame

        {
            //控制用户横向移动， a键左键向左移动，d键右键向右移动，如果都没有按下，则不移动
            float movimentoHorizontal =
            Keyboard.current.aKey.isPressed ? -1f :
            Keyboard.current.dKey.isPressed ? 1f :
            Keyboard.current.leftArrowKey.isPressed ? -1f :
            Keyboard.current.rightArrowKey.isPressed ? 1f :
            0f;

            //控制用户纵向移动， w键上键向上移动，s键下键向下移动，如果都没有按下，则不移动

            float movimentoVertical =
            Keyboard.current.wKey.isPressed ? 1f :
            Keyboard.current.sKey.isPressed ? -1f :
            Keyboard.current.upArrowKey.isPressed ? 1f :
            Keyboard.current.downArrowKey.isPressed ? -1f :
            0f;

            //vector3是一个三维向量，x、y、z分别表示三维空间中的三个坐标轴
            Vector3 VectorDesplaczmento = new Vector3(movimentoHorizontal, movimentoVertical, 0f);
            //normalized是将向量的长度归一化为1，保持方向不变，作用是为了让移动速度保持一致，不会因为斜向移动而变快
            //比如，如果玩家同时按下了w和d键，那么移动方向就是斜向右上方，如果不归一化，那么移动速度就会变快，因为斜向移动的速度是水平和垂直速度的平方和的平方根，所以归一化后，移动速度就会保持一致
            VectorDesplaczmento = VectorDesplaczmento.normalized;

            //movimos l'objecte segons:1) la direccion (vectorDesplazamiento) i 2) la velocidad 
            //我们移动物体根据：1) 方向 (vectorDesplazamiento) 和 2) 速度
            //nuevaDesplazamiento和VectorDesplaczmento的区别是，nuevaDesplazamiento是经过速度和时间间隔计算后的位移向量，而VectorDesplaczmento是原始的方向向量，nuevaDesplazamiento是最终的位移向量，用于移动物体
            Vector3 nuevaDesplazamiento = new Vector3(
                //time.deltaTime是每一帧的时间间隔，作用是让移动速度保持一致，不会因为帧率不同而变快或变慢
                //如果不乘以time.deltaTime，那么移动速度就会随着帧率的不同而变快或变慢，因为每一帧的时间间隔不同，所以移动的距离也不同
                vel * VectorDesplaczmento.x * Time.deltaTime,
                vel * VectorDesplaczmento.y * Time.deltaTime,
                0f
            );

            //transform.position是物体在三维空间中的位置，+=是将新的位移向量加到原来的位置上，从而实现移动物体的效果
            transform.position += nuevaDesplazamiento;
        }

    }
}
