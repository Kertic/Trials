using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public static class CustomMathFunctions
{
    
    /// <summary>
    /// Returns a -1 if the number is negitive, or a positive 1 otherwise
    /// </summary>
    /// <param name="value">The number to find the sign of</param>
    /// <returns></returns>
   public static float ReturnSign(float value)
    {
        if (value == 0)
            return 1;


        return (value / Math.Abs(value));

    }


}
