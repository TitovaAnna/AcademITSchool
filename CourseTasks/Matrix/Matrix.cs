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
        private Vector.Vector[] rows;

        public Matrix(int columnsNumber, int rowsNumber)
        {
            if (columnsNumber <= 0)
            {
                throw new ArgumentException("Количество столбцов матрицы должно быть больше 0");
            }

            if (rowsNumber <= 0)
            {
                throw new ArgumentException("Количество строк матрицы должно быть больше 0");
            }

            rows = new Vector.Vector[rowsNumber];
            for (int i = 0; i < rowsNumber; i++)
            {
                rows[i] = new Vector.Vector(columnsNumber);
            }
        }

        public Matrix(double[,] components)
        {
            rows = new Vector.Vector[components.GetLength(0)];
            for (int i = 0; i < components.GetLength(0); i++)
            {
                double[] array = new double[components.GetLength(1)];
                for (int j = 0; j < components.GetLength(1); j++)
                {
                    array[j] = components[i, j];
                }
                Vector.Vector vector = new Vector.Vector(array);
                rows[i] = vector;
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
            rows = new Vector.Vector[length];
            for (int i = 0; i < length; i++)
            {
                Vector.Vector vector = new Vector.Vector(array[i]);
                rows[i] = vector;
            }
        }

        public Matrix(Matrix matrix) : this(matrix.rows)
        {
        }

        public double this[int i, int j]
        {
            get
            {
                if (i >= this.GetNumberRows())
                {
                    throw new ArgumentOutOfRangeException("Индекс i больше количества строк");
                }
                if (j >= this.GetNumberColumns())
                {
                    throw new ArgumentOutOfRangeException("Индекс j больше количества столбцов");
                }
                return rows[i][j];
            }
            set
            {
                if (i >= this.GetNumberRows())
                {
                    throw new ArgumentOutOfRangeException("Индекс i больше количества строк");
                }
                if (j >= this.GetNumberColumns())
                {
                    throw new ArgumentOutOfRangeException("Индекс j больше количества столбцов");
                }
                rows[i][j] = value;
            }
        }


        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);
            matrixCopy.Add(matrix2);
            return matrixCopy;
        }
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixCopy = new Matrix(matrix1);
            matrixCopy.Subtract(matrix2);
            return matrixCopy;
        }


        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
            {
                return true;
            }
            if (ReferenceEquals(matrix1, null) || (ReferenceEquals(matrix2, null) || matrix1.GetType() != matrix2.GetType()))
            {
                return false;
            }

            if ((matrix1.GetNumberColumns() != matrix2.GetNumberColumns()) || (matrix1.GetNumberRows() != matrix2.GetNumberRows()))
            {
                return false;
            }

            for (int i = 0; i < matrix1.GetNumberRows(); i++)
            {
                for (int j = 0; j < matrix1.GetNumberColumns(); j++)
                {

                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1 == matrix2);
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{{");
            sb.Append(rows[0].GetComponent(0));
            for (int j = 1; j < rows[0].GetSize(); j++)
            {
                sb.Append(", ");
                sb.Append(rows[0].GetComponent(j));
            }
            sb.Append("}");

            for (int i = 1; i < rows.Length; i++)
            {
                sb.Append(", {");
                sb.Append(rows[i].GetComponent(0));
                for (int j = 1; j < rows[i].GetSize(); j++)
                {
                    sb.Append(", ");
                    sb.Append(rows[i].GetComponent(j));
                }
                sb.Append("}");
            }
            sb.Append("}");
            return sb.ToString();
        }

        public int GetNumberRows()
        {
            return rows.Length;
        }

        public int GetNumberColumns()
        {
            return rows[0].GetSize();
        }


        public Vector.Vector GetRow(int index)
        {
            return new Vector.Vector(rows[index]);
        }

        public void SetRow(Vector.Vector vector, int index)
        {
            int lengthVector = vector.GetSize();
            int lengthMatrix = rows.Length;
            if (lengthVector != rows[0].GetSize())
            {
                throw new ArgumentException("Вектор должен совпадать по размеру с длиной строки матрицы");
            }
            if (index > lengthMatrix - 1)
            {
                throw new ArgumentOutOfRangeException("Слишком большой индекс новой строки");
            }

            Vector.Vector vectorNew = new Vector.Vector(vector);
            rows[index] = vectorNew;
        }

        public Vector.Vector GetColumn(int index)
        {
            if (index >= rows[0].GetSize())
            {
                throw new ArgumentOutOfRangeException("Индекс не может быть больше длины вектора");
            }
            double[] array = new double[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                array[i] = rows[i].GetComponent(index);
            }
            return new Vector.Vector(array);
        }

        public void Transposition()
        {
            for (int i = 0; i < this.GetNumberColumns(); i++)
            {
                rows[i] = GetColumn(i);
            }
        }

        public void MultiplyScalar(double scalar)
        {
            foreach (Vector.Vector vector in rows)
            {
                vector.MultiplyScalar(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (rows.Length != rows[0].GetSize())
            {
                throw new InvalidOperationException("Необходима квадратная матрица для расчета определителя");
            }
            int length = rows.Length;
            double[,] array = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = rows[i].GetComponent(j);
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

        private static double CalculateDeterminant(double[,] array)
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

        public Vector.Vector MultiplyVector(Vector.Vector vector)
        {
            int lengthVector = vector.GetSize();
            if (lengthVector != rows[0].GetSize())
            {
                throw new ArgumentException("Размерность вектора должна совпадать с количеством столбцов матрицы");
            }
            int length = rows.Length;
            double[] array = new double[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = Vector.Vector.GetScalarMultiplication(rows[i], vector);
            }
            return new Vector.Vector(array);
        }

        public void Add(Matrix matrix)
        {
            int length = rows.Length;
            int lengthRow = rows[0].GetSize();
            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("Размерность матриц должны быть одинаковая");
            }
            for (int i = 0; i < length; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int length = rows.Length;
            int lengthRow = rows[0].GetSize();
            if ((length != matrix.GetNumberRows()) || (lengthRow != matrix.GetNumberColumns()))
            {
                throw new ArgumentException("Размерность матриц должны быть одинаковая");
            }
            for (int i = 0; i < length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public Matrix Multiply(Matrix matrix)
        {
            int length = rows.Length;
            int countColumns = rows[0].GetSize();
            int lengthMatrix = matrix.GetNumberRows();
            int countColumnsMatrix = matrix.GetNumberColumns();

            if (countColumns != lengthMatrix)
            {
                throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк во второй");
            }
            double[,] multiplyArray = new double[length, countColumnsMatrix];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < countColumnsMatrix; j++)
                {
                    double sum = 0;
                    for (int r = 0; r < countColumns; r++)
                    {
                        sum += rows[i].GetComponent(r) * matrix.rows[r].GetComponent(j);
                    }
                    multiplyArray[i, j] = sum;
                }
            }
            return new Matrix(multiplyArray);
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
