#-------------------------------------------------------------------------------------------------------------------------------------------------------
#Cemal Akif Özateş/salffev
#-------------------------------------------------------------------------------------------------------------------------------------------------------
#Insertion Sort:

#Verilen dizi: [22, 27, 16, 2, 18, 6]

#1-Adım: [22, 27, 16, 2, 18, 6] (Dizi zaten sıralı bir elemandan oluştuğu için ilk elemanı ele alıp bir değişkene atıyoruz.)
#2-Adım: [22, 27, 16, 2, 18, 6] (İkinci eleman olan 27'yi, önceki eleman olan 22 ile karşılaştırıp, uygun yere yerleştiriyoruz.)
#3-Adım: [22, 27, 16, 2, 18, 6] (Üçüncü eleman olan 16'yı, daha önce sıralanmış olan 22 ve 27 ile karşılaştırarak, uygun yere yerleştiriyoruz.)
#4-Adım: [2, 22, 27, 16, 18, 6] (Dördüncü eleman olan 2'yi, daha önce sıralanmış olan 22, 27 ve 16 ile karşılaştırıp, uygun yere yerleştiriyoruz.)
#5-Adım: [2, 18, 22, 27, 16, 6] (Beşinci eleman olan 18'i, 2, 22, 27 ve 16 ile karşılaştırıp, uygun yere yerleştiriyoruz.)
#6-Adım: [2, 6, 18, 22, 27, 16] (Altıncı eleman olan 6'yı, 2, 18, 22, 27 ve 16 ile karşılaştırıp, uygun yere yerleştiriyoruz.)
#7-Adım: [2, 6, 16, 18, 22, 27] (Son adımda artık dizimiz sıralı hale gelmiş durumda.)

#Big-O'ın Gösterimi:

#Insertion Sort'un ortalama, iyi ve kötü durum kargaşası O(n^2) şeklindedir.

#Time Complexity (Zaman Karmaşıklığı) Sorusu:

#Dizi sıralandıktan sonra 18 sayısının Time Complexity'si Average case (ortalama hali) kapsamına giriyor. Çünkü Insertion Sort,
# verilen dizinin neredeyse sıralı olduğu durumlarda daha iyi performans gösterir ve bu duruma Average case denir. 18 sayısı dizinin
#ortasında yer aldığı için bu durum ortalama durum olarak kabul edilir.

#Selection Sort:

#Dizi: [7, 3, 5, 8, 2, 9, 4, 15, 6]

#1-Adım: [2, 3, 5, 8, 7, 9, 4, 15, 6] (Dizi içinde en küçük eleman olan 2'yi başa alıyoruz.)
#2-Adım: [2, 3, 5, 8, 7, 9, 4, 15, 6] (İkinci en küçük eleman olan 3'ü, 2'den sonraki ilk eleman ile yer değiştiriyoruz.)
#3-Adım: [2, 3, 4, 8, 7, 9, 5, 15, 6] (Üçüncü en küçük eleman olan 4'ü, 3'ten sonraki ilk eleman ile yer değiştiriyoruz.)
#4-Adım: [2, 3, 4, 5, 7, 9, 8, 15, 6] (Dördüncü en küçük eleman olan 5'i, 4'ten sonraki ilk eleman ile yer değiştiriyoruz.)
#-------------------------------------------------------------------------------------------------------------------------------------------------------
#ödevimin kodlanmış hali.
using System;

public class Program
{
    public static void Main()
    {
        int[] array = { 7, 3, 5, 8, 2, 9, 4, 15, 6 };
        SelectionSort(array);
        Console.WriteLine("Sorted array:");
        PrintArray(array, array.Length);
    }

    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }
            // Swap the found minimum element with the first element
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    public static void PrintArray(int[] arr, int size)
    {
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
#----------------------------------------------------------------------------------------------------------------------------------------------------------
#Aşağıdaki kod, Insertion Sort algoritması.
public static void InsertionSort(int[] array)
{
  for (int i = 1; i < array.Length; i++)
  {
    int current = array[i];
    int j = i - 1;
    while (j >= 0 && array[j] > current)
    {
      array[j + 1] = array[j];
      j--;
    }
    array[j + 1] = current;
  }
}
#-----------------------------------------------------------------------------------------------------------------------------------------------------------
#aşağıdaki kod selection shorrt algoritması.
public static void SelectionSort(int[] array)
{
  for (int i = 0; i < array.Length - 1; i++)
  {
    int minIndex = i;
    for (int j = i + 1; j < array.Length; j++)
    {
      if (array[j] < array[minIndex])
      {
        minIndex = j;
      }
    }
    int temp = array[i];
    array[i] = array[minIndex];
    array[minIndex] = temp;
  }
}
#-----------------------------------------------------------------------------------------------------------------------------------------------------------