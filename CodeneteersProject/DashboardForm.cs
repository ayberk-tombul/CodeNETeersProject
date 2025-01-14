﻿
using BusinessLayer.Concrete;
using CodeneteersProject;
using DataAccesLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeNETeersProject
{
    public partial class DashboardForm : Form
    {
        CompaniesManager companiesManager = new CompaniesManager(new CompaniesDAL());
        UserManager userManager = new UserManager(new UserDAL());
        PermissionsManager permissions = new PermissionsManager(new PermissionsDAL());
        JobAdvertisementsManager job = new JobAdvertisementsManager(new JobAdvertisementsDAL());
        RestManager rest = new RestManager(new RestDAL());
        SuggestionsManager suggestions = new SuggestionsManager(new SuggestionsDAL());

        EntityLayer.Concrete.User appUser;
        EntityLayer.Concrete.Companies companies;
        public DashboardForm()
        {
            InitializeComponent();
        }

        public DashboardForm(EntityLayer.Concrete.User appUser)
        {
            InitializeComponent();
            this.appUser = appUser;
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load_1(object sender, EventArgs e)
        {
            userNameLabel.Text = appUser.name + " " + appUser.surname;
            companies = new EntityLayer.Concrete.Companies();
            companies = companiesManager.GetByID(appUser.companyID);
            companyLabel.Text = companies.name;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var user = userManager.GetByID(1);
            label1.Text = user.name + " " + user.surname;
            userNameLabel.Text = user.name;
            var companyinfo = companiesManager.GetByID(user.companyID);
            companyLabel.Text = companyinfo.name;
            izinCount.Text = Convert.ToString(permissions.list().Count());
            ilanlarCount.Text = Convert.ToString(job.list().Count());
            personelCount.Text = Convert.ToString(userManager.GetCompaniesPersonel(user.companyID).Count());

            var sonIlan = job.GetCompanyJobAdvertisementsList(user.companyID).OrderByDescending(x => x.ID).FirstOrDefault();
            if (sonIlan != null) { sonIlanText.Text = sonIlan.title; }


            var sontalep = rest.GetUserRestList(user.ID).OrderByDescending(x => x.ID).FirstOrDefault();
            if (sontalep != null) { sonIzınTalep.Text = sontalep.startDate.ToShortDateString(); }

            var sondilek = suggestions.GetUserSuggestionList(user.ID).OrderByDescending(x => x.ID).FirstOrDefault();
            if (sondilek != null) { sonDilekOneri.Text = sondilek.title; }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton7_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sonIzınTalep_Click(object sender, EventArgs e)
        {

        }

        private void addsAndEventsButton_Click(object sender, EventArgs e)
        {

        }

        private void jobAdvertisementsButton_Click(object sender, EventArgs e)
        {
            JobAdvertisementsForm jobAdvertisementsForm = new JobAdvertisementsForm(appUser);
            this.Hide();
            jobAdvertisementsForm.Show();
        }
    }
}
