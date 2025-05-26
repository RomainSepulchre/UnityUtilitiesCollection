using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace RS.Extensions
{
    public static class GeneralExtensions
    {
        #region Monobehaviour
        /// <summary>
        /// Start a couroutine to call an action after a specified amount of time
        /// </summary>
        /// <param name="monoBehaviour">Monobehaviour that call the extension method</param>
        /// <param name="action">Action to invoke</param>
        /// <param name="time">Amount of time to wait before calling the action </param>
        /// <returns></returns>
        public static Coroutine Invoke(this MonoBehaviour monoBehaviour, System.Action action, float time)
        {
            return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
        }

        private static IEnumerator InvokeImpl(System.Action action, float time)
        {
            yield return new WaitForSeconds(time);

            action();
        }
        #endregion

        #region String Manipulation

        /// <summary>
        /// Change the first character of a string to uppercase
        /// </summary>
        /// <param name="str">String that call the extension method</param>
        /// <returns>Same string with the first character changed to uppercase</returns>
        public static string UpperFirstCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }

            return str.ToUpper();
        }

        /// <summary>
        /// Change the first character of a string to lowercase
        /// </summary>
        /// <param name="str">String that call the extension method</param>
        /// <returns>Same string with the first character changed to lowercase</returns>
        public static string LowerFirstCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length > 1)
            {
                return char.ToLower(str[0]) + str.Substring(1);
            }

            return str.ToUpper();
        }

        /// <summary>
        /// Add size rich text tag to set text size
        /// </summary>
        /// <param name="str">String that call the extension method</param>
        /// <param name="size">Size to use for the rich text</param>
        /// <param name="startIndex">Index of where the openning tag should be added</param>
        /// <returns>Same text with the added size rich text tag</returns>
        public static string SetRichSize(this string str, int size, int startIndex=0)
        {
            return str.SetRichSize(size, startIndex, str.Length - startIndex);
        }

        /// <summary>
        /// Add <size> rich text tag to set text size
        /// </summary>
        /// <param name="str">String that call the extension method</param>
        /// <param name="size">Size to use for the rich text</param>
        /// <param name="startIndex">Index of where the openning tag should be added</param>
        /// <param name="count">Number of character before closing the size tag</param>
        /// <returns>Same text with the added size rich text tag</returns>
        public static string SetRichSize(this string str, int size, int startIndex, int count)
        {
            StringBuilder sb = new StringBuilder(str.Substring(0, startIndex));

            sb.Append($"<size={size}>");
            sb.Append(str.Substring(startIndex, count));
            sb.Append("</size>");
            sb.Append(str.Substring(startIndex + count));

            return sb.ToString();
        }

        #endregion

        #region List and Arrays (IList)

        // List / Array as string
        
        /// <summary>
        /// Merge all the entries in a single string
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        /// <param name="separator">Separator added between every entry</param>
        /// <param name="ignoreEmptyEntries">Should we ignore the empty entries</param>
        /// <returns>The list as a single string that merge every entries</returns>
        public static string MergeAsString<T>(this IList<T> list, string separator = "\n", bool ignoreEmptyEntries = true)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                if (ignoreEmptyEntries && string.IsNullOrEmpty(list[i].ToString()))
                {
                    continue;
                }

                if (sb.Length > 0)
                {
                    sb.Append(separator);
                }

                sb.Append(list[i]);
            }

            return sb.ToString();
        }

        // List / Array De-duplication

        /// <summary>
        /// Remove any duplicate
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        public static void RemoveDuplicate<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (Equals(list[i], list[j]))
                    {
                        list.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

        // List / Array Last element

        /// <summary>
        /// Get the last element
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        /// <returns>Last element</returns>
        public static T LastElement<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                Debug.LogError("No element in list, returning default");
                return default(T);
            }

            return list[list.Count - 1];
        }

        /// <summary>
        /// Get the last element and remove it before returning it
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        /// <returns>Last element</returns>
        public static T PopLast<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                Debug.LogError("No element in list, returning default");
                return default(T);
            }

            T last = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return last;
        }

        // List / Array Randomization

        private static Random _random = new Random();

        /// <summary>
        /// Get a random element
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        /// <returns>A random element from the list</returns>
        public static T RandomElement<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                Debug.LogError("No element in list, returning default");
                return default(T);
            }

            int choice = _random.Next(list.Count);

            return list[choice];
        }

        /// <summary>
        /// Get a random element and remove it before returning it
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        /// <returns>A random element from the list</returns>
        public static T RandomPop<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                Debug.LogError("No element in list, returning default");
                return default(T);
            }

            int choice = _random.Next(list.Count);

            T element = list[choice];
            list.RemoveAt(choice);
            return element;
        }

        /// <summary>
        /// Shuffle the elements (semi random fast shuffle)
        /// </summary>
        /// <typeparam name="T">Type contained in the Ilist</typeparam>
        /// <param name="list">IList that call the extension method</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion

        #region Image
        /// <summary>
        /// Set the color alpha value of an image
        /// </summary>
        /// <param name="img">Image that call the extension method</param>
        /// <param name="value">New color alpha value (0 to 1)</param>
        public static void SetColorAlpha(this Image img, float value)
        {
            Color c = img.color;
            c.a = value;
            img.color = c;
        }
        #endregion
    }
}
