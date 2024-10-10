using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace БарУсм
{
    public partial class Form1 : Form
    {
        private double[,] matrix;
        private int rows;
        private int cols;
        private int currentRow = 0;
        public Form1()
        {
            InitializeComponent();
            rows = 3; // Пример значения
            cols = 4; // Пример значения
            matrix = new double[rows, cols];
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentRow < rows)
            {
                string[] values = txtInput.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length == cols)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (double.TryParse(values[col], out double result))
                        {
                            matrix[currentRow, col] = result;
                        }
                        else
                        {
                            MessageBox.Show("Пожалуйста, введите корректные числа.");
                            return;
                        }
                    }
                    currentRow++;
                    txtInput.Clear();
                }
                else
                {
                    MessageBox.Show($"Пожалуйста, введите {cols} значений.");
                }

                if (currentRow == rows)
                {
                    DisplayMatrix();
                }
            }
        }
        private void DisplayMatrix()
        {
            dataGridView.ColumnCount = rows;
            dataGridView.RowCount = cols;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    dataGridView.Rows[col].Cells[row].Value = matrix[row, col];
                }
            }
        }
    }
}

