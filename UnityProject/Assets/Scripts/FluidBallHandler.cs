using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidBallHandler : MonoBehaviour
{
    GameObject marchingCubes;

    public float charge = 1f;

    PointCharge pointCharge;

    void Awake()
    {
        marchingCubes = GameObject.Find("Marching Cubes");
    }

    void Start()
    {
        pointCharge = new PointCharge(this.transform.position, charge);

        marchingCubes.GetComponent<Potential>().RegisterCharge(pointCharge);
    }

    void Update()
    {
        marchingCubes.GetComponent<Potential>().RemoveCharge(pointCharge);

        pointCharge = new PointCharge(this.transform.position, charge);

        marchingCubes.GetComponent<Potential>().RegisterCharge(pointCharge);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Floor")
        {
            marchingCubes.GetComponent<Potential>().RemoveCharge(pointCharge);
            Destroy(this.gameObject);
        }
    }
}
