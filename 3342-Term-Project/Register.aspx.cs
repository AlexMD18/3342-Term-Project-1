﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ClassLibrary;
using System.Net.Mail;

namespace _3342_Term_Project
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
        }
        protected void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pwdValidator.IsValid = false;
                pwdValidator.ErrorMessage = "Password does not match!";
            }
            else
            {
                /*
                MailAddress fromAddress = new MailAddress("jiparkhwan@gmail.com", "Lexpark Movies");
                MailAddress toAddress = new MailAddress(txtEmail.Text, "New User");
                MailMessage verificationMail = new MailMessage(fromAddress.Address, toAddress.Address);
                verificationMail.Subject = "Lexpark: New Account Verification";
                verificationMail.Body = "Click this link to verify your new account. http://localhost:55733/VerifiedPage.aspx";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(fromAddress.Address, "asdasdasd");
                client.Send(verificationMail);
                /*
                    Email objEmail = new Email();


                    string strTO = txtEmail.Text;
                    string strFROM = "jiparkhwan@gmail.com";
                    string strSubject = "LexPark Registration Confirmation";
                    string strMessage = "Hello, click on the link to activate your account: http://localhost:55733/VerifiedPage.aspx";
           
                        objEmail.SendMail(strTO, strFROM, strSubject, strMessage);

                        Error.Text = "An email was sent to verify account!";
                        */
                int result = StoredProcedures.addMemberAccountRegister(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtPassword.Text, txtDOB.Text,
                        ddlSecurityQuestion1.SelectedValue.ToString(), ddlSecurityQuestion2.SelectedValue.ToString(), ddlSecurityQuestion3.SelectedValue.ToString(),
                        txtSecurityAnswer1.Text, txtSecurityAnswer2.Text, txtSecurityAnswer3.Text);
                    
                    if (result > 0)
                    {
                        Session["RegisterEmailVerified"] = txtEmail.Text;


                        //Error.Text = "Check your email to verify your account!";
                    Error.Text = "Account has been successfully made!";
                    }
                 

                }
             
            




        } //end of Submit_Click
    } //end of class
} //end of namespace