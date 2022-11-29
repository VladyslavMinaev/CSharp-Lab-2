﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharp_LB2_Var4
{
    public partial class FormFactory
    {
        TextBox hiringFiringTextBox;
        Form formHiringFiring;
        ComboBox comboBoxHiringFiringFactories;
        Label addLabelInfo;
        int statusWork;

        //ініціалізація форми найму/звільнення працівників
        public void initializeFormHiringFiring(int funcStatusWork)
        {
            statusWork = funcStatusWork;
            formHiringFiring = new Form()
            {
                Width = 350,
                Height = 225,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                Text = "Найм/звільнення працівників"
            };
            formHiringFiring.Show();

            comboBoxHiringFiringFactories = new ComboBox()
            {
                Location = new Point(20, 20),
                Width = 250
            };
            addComboBoxInfo(comboBoxHiringFiringFactories);
            formHiringFiring.Controls.Add(comboBoxHiringFiringFactories);
            comboBoxHiringFiringFactories.SelectedIndexChanged += new System.EventHandler(comboBoxHiringFiringFactories_SelectedIndexChanged);
            addLabelInfo = new Label()
            {
                Location = new Point(20, 60),
                Width = 500,
                Height = 40
            };
            formHiringFiring.Controls.Add(addLabelInfo);

            hiringFiringTextBox = new TextBox()
            {
                Location = new Point(20, 110),
                Width = 250
            };
            formHiringFiring.Controls.Add(hiringFiringTextBox);

            Button buttonDone = new Button()
            {
                Location = new Point(100, 140),
                Width = 80,
                Height = 30,
                Text = "Done"
            };
            buttonDone.Click += new System.EventHandler(buttonDoneHiringFiringOnClick);
            formHiringFiring.Controls.Add(buttonDone);
        }

        private void comboBoxHiringFiringFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusWork == 1)
            {
                addLabelInfo.Text = "Зараз в цьому заводі " + arr.ElementAt(comboBoxHiringFiringFactories.SelectedIndex).amountWorkers + " робітників" + ".\n" +
                    "Для звільнення в полі перед числом допишіть знак -";
            }
            else
            {
                addLabelInfo.Text = "Зараз в цьому заводі " + arr.ElementAt(comboBoxHiringFiringFactories.SelectedIndex).amountCraftsmen + " майстрів" + ".\n" +
                    "Для звільнення в полі перед числом допишіть знак -";
            }
        }

        private void buttonDoneHiringFiringOnClick(object sender, EventArgs eventArgs)
        {
            int resultAdd = 0;
            Int32.TryParse(hiringFiringTextBox.Text, out resultAdd);

            if (hiringFiringTextBox.Text == "")
                MessageBox.Show("Введіть значення!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (resultAdd == 0)
                MessageBox.Show("Неправильний формат даних!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (statusWork == 1)
                    arr.ElementAt(comboBoxHiringFiringFactories.SelectedIndex).amountWorkers += resultAdd;
                else
                    arr.ElementAt(comboBoxHiringFiringFactories.SelectedIndex).amountCraftsmen += resultAdd;
                MessageBox.Show("Успішно!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formHiringFiring.Close();
            }
        }
    }
}
