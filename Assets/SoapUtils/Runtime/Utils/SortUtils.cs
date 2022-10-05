using UnityEngine;

namespace SoapUtils.Runtime.Utils
{
    public static class SortUtils
    {
        public static T[] BubbleSort<T>(int[] orderArray, T[] sortArray)
        {
            if (orderArray.Length != sortArray.Length)
            {
                Debug.LogWarning("array length not equal");
                return null;
            }

            int len = sortArray.Length;

            for (int i = 1; i < len; i++) // 排序次數
            {
                for (int j = 1; j < len; j++) // 執行次數
                {
                    if (orderArray[j] < orderArray[j - 1])
                    {
                        int tempOrder = orderArray[j];
                        T   temp  = sortArray[j];

                        orderArray[j] = orderArray[j - 1];
                        sortArray[j]  = sortArray[j  - 1];

                        orderArray[j - 1] = tempOrder;
                        sortArray[j  - 1] = temp;
                    }
                }
            }
            
            return sortArray;
        }
    }
}