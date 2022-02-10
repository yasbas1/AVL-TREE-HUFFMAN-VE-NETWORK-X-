using System;
namespace Huffman
{
    class Huffman
    {
        public class MinHeap
        {
            private readonly HuffmanNode[] _elements;
            private int _size;

            public MinHeap(int size)
            {
                _elements = new HuffmanNode[size];
            }

            private HuffmanNode GetLeftChildIndex(HuffmanNode elementIndex) => 2 * elementIndex + 1;
            private HuffmanNode GetRightChildIndex(HuffmanNode elementIndex) => 2 * elementIndex + 2;
            private HuffmanNode GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

            private bool HasLeftChild(HuffmanNode elementIndex) => GetLeftChildIndex(elementIndex) < _size;
            private bool HasRightChild(HuffmanNode elementIndex) => GetRightChildIndex(elementIndex) < _size;
            private bool IsRoot(HuffmanNode elementIndex) => elementIndex == 0;

            private HuffmanNode GetLeftChild(HuffmanNode elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
            private HuffmanNode GetRightChild(HuffmanNode elementIndex) => _elements[GetRightChildIndex(elementIndex)];
            private HuffmanNode GetParent(HuffmanNode elementIndex) => _elements[GetParentIndex(elementIndex)];

            private void Swap(int firstIndex, int secondIndex)
            {
                var temp = _elements[firstIndex];
                _elements[firstIndex] = _elements[secondIndex];
                _elements[secondIndex] = temp;
            }

            public bool IsEmpty()
            {
                return _size == 0;
            }

            public int Peek()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                return _elements[0];
            }

            public int Pop()
            {
                if (_size == 0)
                    throw new IndexOutOfRangeException();

                var result = _elements[0];
                _elements[0] = _elements[_size - 1];
                _size--;

                ReCalculateDown();

                return result;
            }

            public void Add(HuffmanNode node)
            {
                if (_size == _elements.Length)
                    throw new IndexOutOfRangeException();

                _elements[_size] = node;
                _size++;

                ReCalculateUp();
            }

            private void ReCalculateDown()
            {
                int index = 0;
                while (HasLeftChild(index))
                {
                    var smallerIndex = GetLeftChildIndex(index);
                    if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                    {
                        smallerIndex = GetRightChildIndex(index);
                    }

                    if (_elements[smallerIndex] >= _elements[index])
                    {
                        break;
                    }

                    Swap(smallerIndex, index);
                    index = smallerIndex;
                }
            }

            private void ReCalculateUp()
            {
                var index = _size - 1;
                while (!IsRoot(index) && _elements[index] < GetParent(index))
                {
                    var parentIndex = GetParentIndex(index);
                    Swap(parentIndex, index);
                    index = parentIndex;
                }
            }
        }

        public class HuffmanNode
        {
            public int frekans;
            public char harf;

            HuffmanNode left;
            HuffmanNode right;

            public HuffmanNode(char harf , int frekans)
            {
                this.frekans = frekans;
                this.harf = harf;
                this.right = null;
                this.left = null;
            }
        }

        public static void main(String[] args)
        {
            int n = 6;
            char[] karakterler = { 'a', 'b', 'c', 'd', 'e', 'f' };
            int[] frekanslar = { 5, 9, 12, 13, 16, 45 };

            MinHeap minHeap = new MinHeap(karakterler.Length);

            for (int i = 0; i < n; i++)
            {

                HuffmanNode hn = new HuffmanNode(karakterler[i] , frekanslar[i]);
             
                
            }


        }

        static int Comparefrekans(HuffmanNode x, HuffmanNode y)
        {
            if (x.frekans > y.frekans)
            {
                return 1;
            }
            else if (x.frekans < y.frekans)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    
}

