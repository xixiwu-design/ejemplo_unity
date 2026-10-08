using UnityEngine;

public class GenaradorMeteorits : MonoBehaviour
{
    //创建一个陨石预制体的引用
    public GameObject MeteoritoPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //每隔0.5秒生成一个陨石，第一次生成陨石的时间为1秒
        //参数为：方法名，延迟时间，重复时间
        InvokeRepeating("GenerarMeteorito", 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerarMeteorito()
    {
        //创建一个陨石实例
        //prefab是一个模板，Instantiate方法会根据这个模板创建一个新的实例
        GameObject meteoritoGenerado = Instantiate(MeteoritoPrefab);

        //设置陨石的位置，x轴在-6.5到6.5之间，y轴在-3到5之间，z轴为100
        meteoritoGenerado.transform.position = new Vector3(
            Random.Range(ValorsGlobales.limiteIzquierdaX, ValorsGlobales.limiteDerechaX),
            Random.Range(ValorsGlobales.limiteAbajoY, ValorsGlobales.limiteArribaY),
            ValorsGlobales.limiteZPositivo
        );
    }
}
