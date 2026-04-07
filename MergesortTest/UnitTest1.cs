using Microsoft.VisualStudio.TestPlatform.TestHost;
using MergeSort;

namespace MergeSort.Tests
{
    public class UnitTest1
    {

        [Fact]  // Tím označujeme, že jde o testovací metodu      

        public void Merge_EqualLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 3, 5, 2, 3, 6 };
            int[] expectedArray = { 1, 2, 3, 3, 5, 6 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void Merge_NegativeArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { -5, -3, -1, -6, -3, -2 };
            int[] expectedArray = { -6, -5, -3, -3, -2, -1 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void Merge_MixedArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { -1, -3, 5, -6, 2, 3 };
            int[] expectedArray = { -6, -1, -3, 2, 3, 5 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void Merge_DifferentLengthArrays_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 1, 3, 5, 2, 3 };
            int[] expectedArray = { 1, 2, 3, 3, 5 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void Merge_OneLongArray_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 5 };
            int[] expectedArray = { 5 };
            int left = 0;
            int right = array.Length - 1;
            int middle = left + (right - left) / 2;

            // Act - zavoláme testovanou funkci
            MergeSortClass.Merge(array, left, middle, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void MergeSort_OneLongArray_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 5 };
            int[] expectedArray = { 5 };
            int left = 0;
            int right = array.Length - 1;

            // Act - zavoláme testovanou funkci
            MergeSortClass.MergeSort(array, left, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void MergeSort_RegularArray_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { 9, 4, 6, 2, 8, 7, 4 };
            int[] expectedArray = { 2, 4, 4, 6, 7, 8, 9 };
            int left = 0;
            int right = array.Length - 1;

            // Act - zavoláme testovanou funkci
            MergeSortClass.MergeSort(array, left, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
        [Fact]
        public void MergeSort_MixedArray_ReturnsMergedSortedArray()         // Naming convention pro testy: ClassName_FunctionName_ExpectedResult nebo FunctionName_TestSpecifics_ExpectedResult
        {
            // Arrange - nastavme vše co potřebujeme, aby mohla běžet testovaná funkce
            int[] array = { -9, -4, 6, 2, 8, -7, 4 };
            int[] expectedArray = { -9, -7, -4, 2, 4, 6, 8};
            int left = 0;
            int right = array.Length - 1;

            // Act - zavoláme testovanou funkci
            MergeSortClass.MergeSort(array, left, right);

            // Assert - zkontrolujeme to, co nám funkce vrátila
            Assert.Equal(expectedArray, array);
        }
    }
}