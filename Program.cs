using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter number of elements in array: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Index {i} is : ");
                array[i] = int.Parse(Console.ReadLine());
            }
            int l = 0;
            int r = array.Length - 1;
            Console.Clear();
            Console.WriteLine("The array before being sorted:");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.WriteLine(array[i]);
                    break;
                }
                Console.Write($"{array[i]}, ");
            }
            QuickSort(array, l, r);
            Console.WriteLine("Array after being sorted:");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.WriteLine(array[i]);
                    break;
                }
                Console.Write($"{array[i]}, ");
            }
 
            Console.ReadLine();
        }
        
        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int pivot = Partition(arr, l, r);
                if (pivot > 1)
                {
                    Console.WriteLine($"Calling subarray with limit for left with indx {l} = {arr[l]} and limit for right with indx {pivot - 1} = {arr[pivot - 1]}: ");
                    QuickSort(arr, l, pivot - 1);
                }
                if (pivot + 1 < r)
                {
                    Console.WriteLine($"Calling subarray with limit for left with indx {pivot + 1} = {arr[pivot + 1]} and limit for right with indx {r} = {arr[r]}: ");
                    QuickSort(arr, pivot + 1, r);
                }
            }
        }

        public static int Partition(int[] arr, int l, int r)
        {
            int temp;
            int pivotIdx = l++;
            while (true)
            {
                while (arr[l] < arr[pivotIdx])
                {
                    if (l == arr.Length - 1)
                    {
                        break;
                    }
                    Console.WriteLine($"l [{l}] = {arr[l]} < pivot [{pivotIdx}] = {arr[pivotIdx]} => comparing (l + 1) [{l + 1}] with pivot [{pivotIdx}]:");
                    l++;
                }
                while (arr[r] > arr[pivotIdx])
                {
                    Console.WriteLine($"r [{r}] = {arr[r]} > pivot [{pivotIdx}] =  {arr[pivotIdx]} => r - 1:");
                    r--;
                }
                if (l >= r)
                {
                    Console.WriteLine($"Break loop l = [{l}] >= r = [{r}]");
                    break;
                }
                if (arr[l] == arr[r])
                {
                    Console.WriteLine($" l [{l}] = {arr[l]} =  r [{r}] = {arr[r]} => l will be [{l + 1}] = {arr[l + 1]} and r will be [{r - 1}] = {arr[r - 1]}");
                    l++;
                    r--;
                }
                else
                {
                    temp = arr[l];
                    Console.Write($"Swapping l [{l}] = {arr[l]} with r [{r}] = {arr[r]} : ");
                    arr[l] = arr[r];
                    arr[r] = temp;
                    Console.WriteLine($"left idx [{l}] = {arr[l]}, right idx [{r}] = {arr[r]}.");
                }

            }
            Console.Write($"Swapping r [{r}] = {arr[r]} with pivot [{pivotIdx}] = {arr[pivotIdx]}: ");
            temp = arr[r];
            arr[r] = arr[pivotIdx];
            arr[pivotIdx] = temp;
            Console.WriteLine($"r => [{r}] = {arr[r]}, pivot [{pivotIdx}] = {arr[pivotIdx]} return r = {r}...");
            return r;
        }
    }
}
