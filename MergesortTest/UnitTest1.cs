using FluentAssertions;
using MergeSort;

namespace MergesortTest
{
    public class UnitTest1
    {
        [Fact]
        public void MergeSort_Merge_Test()
        {
            int[] testArray = { 8, 5, 11, 1, 4, 99, 57, 67, 23 };

            var result = MergeSortClass.Merge(testArray,1,4,8);

            result.Should().NotBeNull();
            result.Should().BeOfType<int[]>();
            result.Should().NotBeEmpty();
            result.Should().HaveCount(9);
            result.Should().StartWith(8);
            
        }

        [Fact]
        public void MergeSort_Sort_Test()
        {
            int[] testArray = { 8, 5, 11, 1, 4, 99, 57, 67, 23 };

            var result = MergeSortClass.MergeSort(testArray, 0, testArray.Length - 1);

            result.Should().NotBeNull();
            result.Should().ContainInOrder(1, 4, 5, 8, 11);
            result.Should().HaveCount(9);
        }
    }
}