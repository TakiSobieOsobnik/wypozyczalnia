﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace wypozyczalnia
{
    public partial class personForm : Form
    {
        Thread newThread;
        public personForm()
        {
            InitializeComponent();
        }
        private void openNewForm(object obj)  // Tworzenie wątku dla nowego okna
        {
            Application.Run(new mainMenuForm());
        }

        public void initializePersonSwitches(int type)        // Wybieranie odpowuiednich pól dla danego typu klienta
        {
            if(type==1) // Ustawienie aktywnych przełączników dla pracownika
            {
                this.personInfoJobPosition_comboBox.Enabled = true;


                //this.carPriceYear_label.Text = "aaaaaaaaaaa";
                //this.personInfoName_textBox.Enabled = true;
            }
            else if (type == 2) // Ustawienie aktywnych przełączników dla klienta
            {
                //this.carPriceYear_label.Text = "bbbbbbbbbbbbbb";
            }
            else
            {
                // ERROR ?????????????????
            }
        }

        public void isSelectedChecker()
        {
            if (((this.personIdentifierTypeCustomer_radioButton.Checked) || (this.personIdentifierTypeEmployee_radioButton.Checked)) && ((this.personIdentifierClientTypeCompany_radioButton.Checked) || (this.personIdentifierClientTypeHuman_radioButton.Checked)))
            {
                this.personInfo_groupBox.Enabled = true;
                this.personRemove_button.Enabled = true;
                this.personSave_button.Enabled = true;
            }
        }

        public void personIdentifierValueWorker(int value, object sender)
        {
            string valueString = this.personIdentifierID_textBox.Text;
            int valueNumeric = Int32.Parse(valueString) + value;
            this.personIdentifierID_textBox.Text = valueNumeric.ToString();
        }

        private void carCancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
            newThread = new Thread(openNewForm);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }

        private void personIdentifierTypeCustomer_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSelectedChecker();
            this.personInfoPassword_textBox.Enabled = false;
            this.personInfoLogin_textBox.Enabled = false;
            this.personInfoSalary_textBox.Enabled = false;
            this.personInfoJobPosition_comboBox.Enabled = false;
        }

        private void personIdentifierTypeEmployee_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSelectedChecker();
            this.personInfoPassword_textBox.Enabled = true;
            this.personInfoLogin_textBox.Enabled = true;
            this.personInfoSalary_textBox.Enabled = true;
            this.personInfoJobPosition_comboBox.Enabled = true;
        }

        private void personIdentifierClientTypeHuman_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSelectedChecker();
            this.personInfoCompanyName_textBox.Enabled = false;
            this.personInfoFaks_textBox.Enabled = false;
            this.personInfoNip_maskedTextBox.Enabled = false;
            this.personInfoName_textBox.Enabled = true;
            this.personInfoSurname_textBox.Enabled = true;
            this.personInfoPesel_maskedTextBox.Enabled = true;
        }

        private void personIdentifierClientTypeCompany_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            isSelectedChecker();
            this.personInfoCompanyName_textBox.Enabled = true;
            this.personInfoFaks_textBox.Enabled = true;
            this.personInfoNip_maskedTextBox.Enabled = true;
            this.personInfoName_textBox.Enabled = false;
            this.personInfoSurname_textBox.Enabled = false;
            this.personInfoPesel_maskedTextBox.Enabled = false;
        }

        private void personIdentifierNextID_button_Click(object sender, EventArgs e)
        {
            personIdentifierValueWorker(1, this.personIdentifierID_textBox.Text);
        }

        private void personIdentifierPrevID_button_Click(object sender, EventArgs e)
        {
            personIdentifierValueWorker(-1, this.personIdentifierID_textBox.Text);
        }

    }
}
