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
        private Vector.Vector[] matrixRows;

        public Matrix(int columnsNumber, int rowsNumber)
        {
            if (columnsNumber <= 0)
            {
                throw new Vector.IllegalArgumentException("Количество столбцоы матрицы должно быть больше 0");
            }

            if (rowsNumber <= 0)
            {
                throw new Vector.IllegalArgumentException("Количество строк матрицы должно быть больше 0");
            }

            matrixRows = new Vector.Vector[rowsNumber];
            for (int i = 0; i < rowsNumber; i++)
            {
                matrixRows[i] = new Vector.Vector(columnsNumber);
            }
        }

        public Matrix(double[,] components)
        {

            matrixRows = new Vector.Vector[components.GetLength(0)];
            for (int i = 0; i < components.GetLength(0); i++)
            {
                double[] array = new double[components.GetLength(1)];
                for (int j = 0; j < components.GetLength(1); j++)
                {
                    array[j] = components[i, j];
                }
                Vector.Vector vector = new Vector.Vector(array);
                matrixRows[i] = vector;
            }
        }

        public Matrix(Vector.Vector[] array)
        {
            int length = array.Length;
            foreach (Vector.Vector vector in array)
            {
                if (vector.GetSize() != array[0].GetSize())
                {
                    throw new ArgumentException("Все векторы массива должны быть одной длины");
                }
            }
            matrixRows = new Vector.Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vector.Vector vector = new Vector.Vector(array[i]);
                matrixRows[i] = vector;
            }
        }

        public Matrix(Matrix matrix) : this(matrix.matrixRows)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{{");
            sb.Append(matrixRows[0].GetComponent(0));
            for (int j = 1; j < matrixRows[0].GetSize(); j++)
            {
                sb.Append(", ");
                sb.Append(matrixRows[0].GetComponent(j));
            }
            sb.Append("}");

            for (int i = 1; i < matrixRows.Length; i++)
            {
                sb.Append(", {");
                sb.Append(matrixRows[i].GetComponent(0));
                for (int j = 1; j < matrixRows[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(matrixRows[i].GetComponent(j));
                }
                sb.Append("}");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public int GetNumberRows()
        {
            return matrixRows.Length;
        }

        public int GetNumberColumns()
        {
            return matrixRows[0].GetSize();
        }


        public Vector.Vector GetRow(int index)
        {
            return new Vector.Vector(matrixRows[index]);
        }

        public Matrix SetRow(Vector.Vector vector, int index)
        {
            int lengthVector = vector.GetSize();
            int lengthMatrix = matrixRows.Length;
            if (lengthVector != matrixRows[0].GetSize())
            {
                throw new ArgumentException("Вектор должен совпадать по размеру с длиной строки матрицы");
            }
            if (index > lengthMatrix)
            {
                throw new ArgumentOutOfRangeException("Слишком большой индекс новой строки");
            }
            Vector.Vector[] newmatrixRows = new Vector.Vector[lengthMatrix + 1];
            for (int i = lengthMatrix; i >= 0; i--)
            {
                if (i == index)
                {
                    newmatrixRows[i] = vector;
                }
                else if (i > index)
                {
                    newmatrixRows[i] = matrixRows[i - 1];
                }
                else
                {
                    newmatrixRows[i] = matrixRows[i];
                }
            }
            return new Matrix(newmatrixRows);
        }

        public Vector.Vector GetColumn(int index)
        {
            if (index > matrixRows[0].GetSize())
            {
                throw new ArgumentOutOfRangeException("Индекс не может быть больше длины вектора");
            }
            double[] array = new double[matrixRows.Length];
            for (int i = 0; i < matrixRows.Length; i++)
            {
                array[i] = matrixRows[i].GetComponent(index);
            }
            return new Vector.Vector(array);
        }
        public void Transposition()
        {
            for (int i = 0; i < matrixRows[0].GetSize(); i++)
            {
                matrixRows[i] = GetColumn(i);
            }
        }

        public void MultiplyScalar(double scalar)
        {
            foreach (Vector.Vector vector in matrixRows)
            {
                vector.MultiplyScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (matrixRows.Length != matrixRows[0].GetSize())
            {
                throw new InvalidOperationException("Необходима квадратная матрица для расчета определителя");
            }
            int length = matrixRows.Length;
            double[,] array = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = matrixRows[i].GetComponent(j);
                }
            }
            return CalculateDeterminant(array);
        }

        private static double[,] GetMinor(double[,] array, int elementMinor)
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

        private double CalculateDeterminant(double[,] array)
        {
            double determinant = 0;
            int length = array.GetLength(0);
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
                determinant += array[0, i] * Math.Pow(-1, i) * CalculateDeterminant(GetMinor(array, i));
            }
            return determinant;
        }

        public void MultiplyVector(Vector.Vector vector)
        {
            int lengthVector = vector.GetSize();
            if (lengthVector != matrixRows[0].GetSize())
            {
                throw new ArgumentException("Размерность вектора должна совпадать с количеством столбцов матрицы");
            }
            int lengthMatrix = matrixRows.Length;
            for (int i = 0; i < lengthMatrix; i++)
            {
                for (int j = 0; j < lengthVector; j++)
                {
                    matrixRows[i].SetComponent(matrixRows[i].GetComponent(j) * vector.GetComponent(j), j);
                }
            }
        }
        public void Add(Matrix matrix)
        {
            int length = matrixRows.Length;
            int lengthRow = matrixRows[0].GetSize();

            if ((length == matrix.GetNumberColumns()) && (lengthRow == matrix.GetNumberColumns()))
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < lengthRow; j++)
                    {
                        matrixRows[i].SetComponent(matrixRows[i].GetComponent(j) + matrix.matrixRows[i].GetComponent(j), j);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Размерность матриц должны быть одинаковая");
            }
        }

        public void Subtract(Matrix matrix)
        {
            int length = matrixRows.Length;
            int lengthRow = matrixRows[0].GetSize();

            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("Размерность матриц должны быть одинаковая");
            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < lengthRow; j++)
                {
                    matrixRows[i].SetComponent(matrixRows[i].GetComponent(j) - matrix.matrixRows[i].GetComponent(j), j);
                }
            }
        }

        public Matrix Multiply(Matrix matrix)
        {
            int length = matrixRows.Length;
            int countColumns = matrixRows[0].GetSize();
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
                            Sum += matrixRows[i].GetComponent(r) * matrix.matrixRows[r].GetComponent(j);
                        }
                        multipyArray[i, j] = Sum;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Размерность матриц должны быть одинаковая");
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
