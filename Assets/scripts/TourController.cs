using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourController : MonoBehaviour
{
    public Vector2 pinTopLeft;
    public Vector2 pinBottomRight;
    public Vector2 gameBounds;
    //width and length in lat/lng units
    private Vector2 bounds;
    private Vector2 centerGPS;

    public GameObject userIcon;

    //ratio of distance
    private Vector2 movementRatio;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        //stop if user doesn't allow gps
        if(Input.location.isEnabledByUser){
            yield break;
        }
        Input.location.Start();
        //check for a 25 seconds for access to gps
        int maxWait = 25;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        //Initialization Failed
        if(maxWait<1){
            print("Timed out");
            yield break;
        }
        else{
            //world bounds
            pinTopLeft=new Vector2(Input.location.lastData.latitude-0.001f,Input.location.lastData.longitude+0.001f);
            pinBottomRight=new Vector2(Input.location.lastData.latitude+0.001f,Input.location.lastData.longitude-0.001f);
            bounds = new Vector2(pinTopLeft.x - pinBottomRight.x, pinTopLeft.y - pinBottomRight.y);
            centerGPS = new Vector2(bounds.x/2,bounds.y/2);

            movementRatio = new Vector2(gameBounds.x/bounds.x,gameBounds.y/bounds.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 userPosition = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
        Vector2 uGamePosition = (userPosition - centerGPS) * movementRatio;

        userIcon.transform.position = new Vector3(uGamePosition.y, .1f, uGamePosition.y);
        
    }
}
