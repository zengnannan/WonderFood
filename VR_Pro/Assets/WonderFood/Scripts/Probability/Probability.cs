using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
    /// <summary>
    /// This method return the pool according to the chance which defined in Class Pool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">This List Contains all pools with their chances.</param>
    /// <returns></returns>
    public static T GetChancePool<T>(List<T> list) where T : Pool
    {
        int chanceSum = 0;
        //Example: We have 3 pools in Pool[].
        //Pool[0].chance is 30. Pool[1].chance is 60. Pool[2].chance is 90. 
        //If random number is between 0(inclusive)~30(exclusive), the method will return Pool[0].
        //if random number is between 30(inclusive)~90(exclusive), the method will return Pool[1]. 
        for (int i = 0; i < list.Count; i++)
        {
            T current = list[i];
            chanceSum += current.chance;
            if (i == 0)
            {
                current.minChance = 0;
                current.maxChance = current.chance;
            }
            else
            {
                current.minChance = list[i - 1].maxChance;
                current.maxChance = current.minChance + current.chance;
            }
        }

        int rand = Random.Range(0, chanceSum);
        for (int i = 0; i < list.Count; i++)
        {
            T current = list[i];
            if (rand >= current.minChance && rand < current.maxChance)
            {
                return current;
            }
        }
        return null;
    }
}


