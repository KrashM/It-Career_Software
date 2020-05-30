using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Software_Project.Business{

    public static class Table_Parser{

        /// <summary>
        /// Starts the proces of generating the table with the specified parameters.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <param name="columnHeaders"></param>
        /// <param name="Func<T"></param>
        /// <param name="valueSelectors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The table.</returns>
        public static string ToStringTable<T>(this IEnumerable<T> values, bool type, string[] columnHeaders, params Func<T, object>[] valueSelectors){
            return ToStringTable(values.ToArray(), type, columnHeaders, valueSelectors);
        }

        /// <summary>
        /// Creates the headers of the table and fills the rows.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="type"></param>
        /// <param name="columnHeaders"></param>
        /// <param name="Func<T"></param>
        /// <param name="valueSelectors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The finished table.</returns>
        public static string ToStringTable<T>(this T[] values, bool type, string[] columnHeaders, params Func<T, object>[] valueSelectors){

            Debug.Assert(columnHeaders.Length == valueSelectors.Length);

            var arrValues = new string[values.Length + 1, valueSelectors.Length];

            // Fill headers
            for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                arrValues[0, colIndex] = columnHeaders[colIndex];

            // Fill table rows
            for (int rowIndex = 1; rowIndex < arrValues.GetLength(0); rowIndex++)
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++){

                    object value = valueSelectors[colIndex].Invoke(values[rowIndex - 1]);
                    arrValues[rowIndex, colIndex] = value != null ? value.ToString() : "null";

                }

            return ToStringTable(arrValues, type);

        }

        /// <summary>
        /// Generates the rows of the table.
        /// </summary>
        /// <param name="string["></param>
        /// <param name="arrValues"></param>
        /// <param name="type"></param>
        /// <returns>The rows.</returns>
        public static string ToStringTable(this string[,] arrValues, bool type){

            int[] maxColumnsWidth = GetMaxColumnsWidth(arrValues);
            var headerSpliter = new string('-', maxColumnsWidth.Sum(i => i + 3) - 1);

            var sb = new StringBuilder();
            for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++){

                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++){

                    // Print cell
                    string cell = arrValues[rowIndex, colIndex];
                    cell = (colIndex > 1 && type) ? cell.PadLeft(maxColumnsWidth[colIndex]) : cell.PadRight(maxColumnsWidth[colIndex]);
                    sb.Append(" | ");
                    sb.Append(cell);

                }

                // Print end of line
                sb.Append(" | ");
                sb.AppendLine();

                // Print splitter
                if (rowIndex == 0){

                    sb.AppendFormat(" |{0}| ", headerSpliter);
                    sb.AppendLine();

                }
                // Print splitter
                if (rowIndex == arrValues.GetLength(0) - 2 && type){

                    sb.AppendFormat(" |{0}| ", headerSpliter);
                    sb.AppendLine();

                }

            }

            return sb.ToString();

        }

        /// <summary>
        /// Gets the width of the longest element in every column.
        /// </summary>
        /// <param name="arrValues"></param>
        /// <returns>Array of all the widths.</returns>
        private static int[] GetMaxColumnsWidth(string[,] arrValues){
            
            var maxColumnsWidth = new int[arrValues.GetLength(1)];
            for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++){

                    int newLength = arrValues[rowIndex, colIndex].Length;
                    int oldLength = maxColumnsWidth[colIndex];

                    if (newLength > oldLength) maxColumnsWidth[colIndex] = newLength;

                }

            return maxColumnsWidth;

        }
        
    }

}