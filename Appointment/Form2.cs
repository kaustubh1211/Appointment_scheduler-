﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void AddApointment_Click(object sender, EventArgs e)
        {
            AddAppointment apoint = new AddAppointment();
            apoint.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddClient add = new AddClient();
            add.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DoctorAdd dc = new DoctorAdd();
            dc.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewAppointments ad = new ViewAppointments();
            ad.Show();
            this.Hide();
        }
    }
}
