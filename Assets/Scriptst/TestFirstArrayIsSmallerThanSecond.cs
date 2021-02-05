using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestFirstArrayIsSmallerThanSecond : MonoBehaviour
{
    [SerializeField] private GameObject[] _firstArray;  // первый массив
    [SerializeField] private GameObject[] _secondArray; // второй массив


    void Start()
    {
        StartCoroutine(FillFirstArray()); // Старт куратины
    }

    IEnumerator FillFirstArray() 
    {
        for (int i = 0; i < _firstArray.Length; i++) // проходим по каждому элементу массива _firstArray
        {
            if (_firstArray[i] == null) // Если элемент равент null
            {
                GameObject gameObject = GetRandomObjectFormArray();  // создаем переменную для получения объекта из массива _secondArray

                _firstArray[i] = gameObject; // присваем обьект из второго массива в первый
            }

            yield return new WaitForSeconds(1.0f);
            Debug.Log("Я все");
            Debug.Log(i);
        }
    }
    private GameObject GetRandomObjectFormArray()
    {
        bool _hasObject = CheckSecondArrayIfHasObjects(); // bool переменная , которая принимает данные из функции CheckSecondArrayIfHasObjects()
        bool _firstArrayIsFill = CheckFirstArrayIsFill(); // bool переменная , которая принимает данные из функции CheckFirstArrayIsFill()
        if (_firstArrayIsFill || !_hasObject) // Если _firstArrayIsFill true или !_hasObject false 
        {
            return null; // возвращаем null
        }

        int randNnumber = Random.Range(0, _secondArray.Length); // Создаем переменную , которая будет хранить рандомное число в диапазоне от 0 до размера массива _secondArray

        if (_secondArray[randNnumber] != null) // Если элемент массива _secondArray со значение из переменной randNnumber не равен null/
        {
            GameObject temp = _secondArray[randNnumber]; // Создаем переменную temp и помещаем в нее элемент _secondArray[randNnumber]
            _secondArray[randNnumber] = null; // Присваиваем элементу _secondArray[randNnumber] null
            return temp; // возвращаем переменную[randNnumber] с элементом массива _secondArray
        }

        return GetRandomObjectFormArray(); // Если объект _secondArray[randNnumber] == null, вызваем функцию (рекурсия)
    }


    private bool CheckSecondArrayIfHasObjects() // Проверка на заполненность второго массива
    {
        int count = _secondArray.Length; // переменная счётчик ровна размеру _secondArray

        foreach (var i in _secondArray) // Для каждой i(элемента) во втором Массиве
        {
            if (i != null) // Если i != null
            {
                count--; // переменная счетчик уменьшается
                return true; // Возвращаем true
            }
        }
        if (count == _secondArray.Length) // Если счетчк == размеру массива _secondArray
        {
            return false; // Возвращаем false
        }
        return false; // возвращаем false если не прошли проверки
    }

    private bool CheckFirstArrayIsFill() // Проверка на заполненность первого массива
    {
        int count = 0; // переменная счетчик
        foreach (var i in _firstArray) // Для каждой i(элемента) в первом Массиве
        {
            if (i == null) // Если i == null
            {
                count++; // Увеличиваем счётчик
                return false; // Если i == null, возвращаем false.  
            }
        }
        if (count == 0) // Если счетчик не увеличился
        {
            return true; // возвращаем true
        }
        return false; // возвращаем false если не прошли проверки
    }


    void Update()
    {

    }
}