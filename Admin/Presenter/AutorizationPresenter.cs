﻿using System;
using System.Windows.Forms;
using Cursovaya.Model;
using FileCabinetLibrary.Model;

namespace AdminView.Presenter
{
    //Класс - презентер связывает между собой модель и форму Autorization
    class AutorizationPresenter
    {
        //Constructor
        public AutorizationPresenter(Autorization au)
        {
            auView = au;
            
            admin = new Cursovaya.Model.Admin();
            auView.LogInEvent += AuView_LogInEvent;
        }

        #region Fields
        Cursovaya.Model.Admin admin;
        Autorization auView;
        #endregion

        #region EventHandlers
        private void AuView_LogInEvent(object sender, EventArgs e)
        {
            if (auView.Password == admin.Password && auView.Login == admin.Login)
            {
                auView.Close();
                User.Role = UserRole.Admin;
            }
            else
            {
                MessageBox.Show("Invalid login or password\nTry again");
                auView.Login = "";
                auView.Password = "";
            }
        }
        #endregion

    }
}
