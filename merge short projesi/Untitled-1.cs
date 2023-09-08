#cemal akif özateş/salffev
#--------------------------------------------------------------------------------------------------------------------------------------------------------------#
#16, 21, 11, 8, 12, 22 dizisinin Merge Sort algoritmasıyla nasıl sıralanması gerektiği aşağıda yer almaktadır:

#1-Diziyi iki eş parçaya bölünür: [16, 21] ve [11, 8, 12, 22].
#2-Her parça, daha küçük parçalara bölünür ve tekrar sıralanır.
#3-Sıralanmış parçalar, daha büyük parçalar halinde birleştirilir.
#4-Bu işlem, tüm dizi sıralanana kadar devam eder.

#Big-O gösterimi O(n log n)'dir. Bu, algoritmanın, dizinin uzunluğunun log n katıdır.

1-Adım -->[16, 21, 11] [8, 12, 22]

2-Adım -->sol yarı-->[16] [21, 11]

3-Adım -->sol yarı-->[16] [21] [11]

4-Adım -->birleştirme-->[16] [11, 21]

5-Adım -->sağ yarı-->[8] [12, 22]

6-Adım -->sol yarı-->[8] [12] [22]

7-Adım -->birleştirme-->[8] [12, 22]

8-Adım -->birleştirme-->[8, 12, 22]

9-Adım -->birleştirme-->[8, 11, 16, 21, 22]
#--------------------------------------------------------------------------------------------------------------------------------------------------------------#
public static void MergeSort(int[] arr)
{
    if (arr.Length <= 1)
    {
        return;
    }

    int mid = arr.Length / 2;
    int[] left = new int[mid];
    int[] right = new int[arr.Length - mid];

    for (int i = 0; i < mid; i++)
    {
        left[i] = arr[i];
    }

    for (int i = mid; i < arr.Length; i++)
    {
        right[i - mid] = arr[i];
    }

    MergeSort(left);
    MergeSort(right);

    Merge(left, right, arr);
}

public static void Merge(int[] left, int[] right, int[] arr)
{
    int i = 0;
    int j = 0;
    int k = 0;

    while (i < left.Length && j < right.Length)
    {
        if (left[i] <= right[j])
        {
            arr[k] = left[i];
            i++;
        }
        else
        {
            arr[k] = right[j];
            j++;
        }
        k++;
    }

    while (i < left.Length)
    {
        arr[k] = left[i];
        i++;
        k++;
    }

    while (j < right.Length)
    {
        arr[k] = right[j];
        j++;
        k++;
    }
}
#--------------------------------------------------------------------------------------------------------------------------------------------------------------#