using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector;

namespace Matrix
{
    class Matrix
    {
        private Vector.Vector[] arrayVectors;

        public Matrix(int columnsNumber, int rowsNumber)
        {
            if ((columnsNumber <= 0) || (rowsNumber <= 0))
            {
                throw new Vector.IllegalArgumentException("Размеры матрицы  должны быть больше 0");
            }

            arrayVectors = new Vector.Vector[rowsNumber];
            for (int i = 0; i < rowsNumber; i++)
            {
                arrayVectors[i] = new Vector.Vector(columnsNumber);
            }
        }

        public Matrix(double[,] components) 
        {

            arrayVectors = new Vector.Vector[components.GetLength(0)];
            for (int i = 0; i < components.GetLength(0); i++)
            {
                double[] array = new double[components.GetLength(1)];
                for (int j = 0; j < components.GetLength(1); j++)
                {
                    array[j] = components[i, j];
                }
                Vector.Vector vector = new Vector.Vector(array);
                arrayVectors[i] = vector;
            }
        }

        public Matrix(Vector.Vector[] array)
        {
            int length = array.Length;
            foreach (Vector.Vector vector in array)
            {
                if (vector.GetSize() != array[0].GetSize())
                {
                    throw new InvalidOperationException("Все векторы массива должны быть одной длины");
                }
            }
            arrayVectors = new Vector.Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vector.Vector vector = new Vector.Vector(array[i]);
                arrayVectors[i] = vector;
            }
        }

        public Matrix(Matrix matrix) : this(matrix.arrayVectors)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{{");
            sb.Append(arrayVectors[0].GetComponent(0));
            for (int j = 1; j < arrayVectors[0].GetSize(); j++)
            {
                sb.Append(", ");
                sb.Append(arrayVectors[0].GetComponent(j));
            }
            sb.Append("}");

            for (int i = 1; i < arrayVectors.Length; i++)
            {
                sb.Append(", {");
                sb.Append(arrayVectors[i].GetComponent(0));
                for (int j = 1; j < arrayVectors[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(arrayVectors[i].GetComponent(j));
                }
                sb.Append("}");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public int GetNumberRows()
        {
            return arrayVectors.Length;
        }

        public int GetNumberColumns()
        {
            return arrayVectors[0].GetSize();
        }


        public Vector.Vector GetRow(int index)
        {
            return new Vector.Vector(arrayVectors[index]);
        }

        public void SetRow(Vector.Vector vector, int index)
        {
            if (vector != arrayVectors[0])
            {
                throw new InvalidOperationException("Вектор должен совпадать по размеру с длиной строки матрицы");
            }
            Vector.Vector vectorCopy = new Vector.Vector(arrayVectors[index]);
            arrayVectors[index] = vectorCopy;
        }

        public Vector.Vector GetColumn(int index)
        {
            if (index > arrayVectors[0].GetSize())
            {
                throw new InvalidOperationException("Индекс не может быть больше длины вектора");
            }
            double[] array = new double[arrayVectors.Length];
            for (int i = 0; i < arrayVectors.Length; i++)
            {
                array[i] = arrayVectors[i].GetComponent(index);
            }
            return new Vector.Vector(array);
        }
        public void Transposition()
        {
            for (int i = 0; i < arrayVectors[0].GetSize(); i++)
            {
                arrayVectors[i] = GetColumn(i);
            }
        }

        public void MultiplyScalar(double scalar)
        {
            foreach (Vector.Vector vector in arrayVectors)
            {
                vector.MultiplyScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (arrayVectors.Length != arrayVectors[0].GetSize())
            {
                throw new InvalidOperationException("Необходима квадратная матрица для расчета определителя");
            }
            int length = arrayVectors.Length;
            double[,] array = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = arrayVectors[i].GetComponent(j);
                }
            }
            return FindDeterminant(array);
        }

        private double[,] FindMinor(double[,] array, int elementMinor)
        {
            int length = array.GetLength(0);
            double[,] minor = new double[length - 1, length - 1];
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (j < elementMinor)
                    {
                        minor[i, j] = array[i + 1, j];
                    }
                    else
                    {
                        minor[i, j] = array[i + 1, j + 1];
                    }
                }
            }
            return minor;
        }

        private double FindDeterminant(double[,] array)
        {
            double determinant = 0;
            double length = array.GetLength(0);
            if (length == 2)
            {
                return (array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0]);
            }
            else if (length == 1)
            {
                return array[0, 0];
            }
            for (int i = 0; i < length; i++)
            {
                determinant += array[0, i] * Math.Pow(-1, i) * FindDeterminant(FindMinor(array, i));
            }
            return determinant;

        }

        public void MultiplyVector(Vector.Vector vector)
        {
            int lengthVector = vector.GetSize();
            if (lengthVector != arrayVectors[0].GetSize())
            {
                throw new InvalidOperationException("Размерность вектора должна совпадать с количеством столбцов матрицы");
            }
            int lengthMatrix = arrayVectors.Length;
            for (int i = 0; i < lengthMatrix; i++)
            {
                for (int j = 0; j < lengthVector; j++)
                {
                    arrayVectors[i].SetComponent(arrayVectors[i].GetComponent(j) * vector.GetComponent(j), j);
                }
            }
        }
        public void Add(Matrix matrix)
        {
            int length = arrayVectors.Length;
            int lengthRow = arrayVectors[0].GetSize();

            if ((length == matrix.GetNumberColumns()) && (lengthRow == matrix.GetNumberColumns()))
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < lengthRow; j++)
                    {
                        arrayVectors[i].SetComponent(arrayVectors[i].GetComponent(j) + matrix.arrayVectors[i].GetComponent(j), j);
                    }
                }
            }

            else
            {
                throw new InvalidOperationException("Размерность матриц должны быть одинаковая");
            }
        }

        public void Subtract(Matrix matrix)
        {
            int length = arrayVectors.Length;
            int lengthRow = arrayVectors[0].GetSize();

            if ((length == matrix.GetNumberRows()) && (lengthRow == matrix.GetNumberColumns()))
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < lengthRow; j++)
                    {
                        arrayVectors[i].SetComponent(arrayVectors[i].GetComponent(j) - matrix.arrayVectors[i].GetComponent(j), j);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Размерность матриц должны быть одинаковая");
            }
        }


        public Matrix Multiply(Matrix matrix)
        {
            int length = arrayVectors.Length;
            int countColumns = arrayVectors[0].GetSize();
            int lengthMatrix = matrix.GetNumberRows();
            int countColumnsMatrix = matrix.GetNumberColumns();
            double[,] multipyArray = new double[length, countColumnsMatrix];
            if ((length == countColumnsMatrix) && (countColumns == lengthMatrix))
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < countColumnsMatrix; j++)
                    {
                        double Sum = 0;
                        for (int r = 0; r < countColumns; r++)
                        {
                            Sum += arrayVectors[i].GetComponent(r) * matrix.arrayVectors[r].GetComponent(j);
                        }
                        multipyArray[i, j] = Sum;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Размерность матриц должны быть одинаковая");
            }
            return new Matrix(multipyArray);
        }

        public static Matrix GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);
            matrixCopy.Subtract(matrix2);
            return matrixCopy;
        }

        public static Matrix GetSumMatrix(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);
            matrixCopy.Add(matrix2);
            return matrixCopy;
        }

        public static Matrix GetMultiplicationMatrix(Matrix matrix1, Matrix matrix2)
        {
            return matrix1.Multiply(matrix2);
        }
    }
}
