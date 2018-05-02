using System;
using System.Collections;
using System.Collections.Generic;

public class Camera
{

    static Dictionary<int, Camera> cameras = new Dictionary<int, Camera>();
    static object lockCamera = new object();

    public static Camera GetCamera(int cameraID)
    {

        if (!cameras.ContainsKey(cameraID))
        {
            lock (lockCamera)
            {

                if (!cameras.ContainsKey(cameraID))
                {
                    cameras.Add(cameraID, new Camera());
                }

            }

        }


        return cameras[cameraID];
    }
}