using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiamondMind.Prototypes.FPSCounter
{
    public class dFPSCounter : MonoBehaviour
    {
        public Text fpsCounterText;
        public Text cPUInfoText;
        public Text gPUInfoText;
        public Text oSInfoText;
        public Text aPIInfoText; 

        public double fps;
        public float lowFPSTreshold = 15f;

        int frameCount;
        float deltaTime;
        float updateRate = 2.0f;
        
        void Start()
        {
            // set the texts to required info
            oSInfoText.text = SystemInfo.operatingSystem;
            cPUInfoText.text = SystemInfo.processorType;
            gPUInfoText.text = SystemInfo.graphicsDeviceName + ", " + SystemInfo.graphicsMemorySize + "MB";
            aPIInfoText.text = SystemInfo.graphicsDeviceVersion;
        }
        void Update()
        {
            // stop counting FPS when game is paused
            if (Time.timeScale == 0)
            {
                return;
            }
            frameCount++;
            deltaTime += Time.deltaTime;
            // calculat fps
            if(deltaTime > 1 / updateRate)
            {
                fps = Math.Round(frameCount / deltaTime, 1);    // round fps to one decimal place
                fpsCounterText.text = fps.ToString() + " FPS";  // convert fps from double to string
                frameCount = 0;
                deltaTime -= 1 / updateRate;
            }
            SetFpsColor();
        }
        void SetFpsColor()
        {
            //change fps color if value is low
            if(fps < lowFPSTreshold)
            {
                fpsCounterText.color = Color.red;
            }
            else
            {
                fpsCounterText.color = Color.green;
            }
        }
    }
}

