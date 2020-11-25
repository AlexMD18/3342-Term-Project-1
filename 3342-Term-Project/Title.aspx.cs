﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ClassLibrary;
namespace _3342_Term_Project
{
    public partial class Title : System.Web.UI.Page
    {
        StoredProcedures SP = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
         
                addReviewLink.Visible = true;
            lblSuccessReview.Text = "";
            addReviewPanel.Visible = false;

            editReviewPanel.Visible = false;


            imgTitleImage.ImageUrl = Session["TitleImage"].ToString();
            lblTitleDescription.Text = Session["TitleDescription"].ToString();

            lblTitleGenre.Text = Session["TitleGenre"].ToString();
            lblTitleName.Text = Session["TitleName"].ToString();
            lblTitleYear.Text = Session["TitleYear"].ToString();
            lblTitleAgeRating.Text = Session["TitleAgeRating"].ToString();

            Page.Title = String.Format(lblTitleName.Text);
            if (Session["TitleCreator"] == null)
            {
                lblTitleCreatorLabel.Visible = false;
                lblTitleCreator.Visible = false;
            }
            else
            {
                lblTitleCreator.Text = Session["TitleCreator"].ToString();
            }

            if (Session["TitleRunTime"] == null)
            {
                lblTitleRunTimeLabel.Visible = false;
                lblTitleRunTime.Visible = false;
            }
            else
            {
                lblTitleRunTime.Text = Session["TitleRunTime"].ToString();
            }

            if (Session["TitleBudget"] == null && Session["TitleIncome"] == null)
            {
                lblTitleIncomeLabel.Visible = false;
                lblTitleIncome.Visible = false;
                lblTitleBudgetLabel.Visible = false;
                lblTitleBudget.Visible = false;
                lblBar2.Visible = false;
            }
            else
            {
                lblTitleBudget.Text = Session["TitleBudget"].ToString();
                lblTitleIncome.Text = Session["TitleIncome"].ToString();
            }


            //review functions here
            if (Convert.ToBoolean(Session["MovieReviews"]) == true)
            {
                int movieID = Convert.ToInt32(Session["MovieID"]);

                DataSet myDS = SP.getMovieReviewsByID(movieID);
                if (myDS.Tables[0].Rows.Count >= 1) //member record found
                {
                    try
                    {
                        gvReviews.DataSource = myDS;
                        gvReviews.DataBind();

                        gvReviews.Visible = true;

                        if (gvReviews.Visible == true)
                        {
                            lblSuccessReview.Text = "";
                            lblError.Text = "";
                        }
                    }
                    catch (Exception E)
                    {
                        lblError.Text = E.Message;
                    }


                }
                else
                {
                    lblError.Text = "No reviews exist for this movie yet! Be the first one: ";
                }
            }
           
            

            else if (Convert.ToBoolean(Session["ShowReviews"]) == true)
            {
              
                    DataSet myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
                    //   myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
                    if (myDS.Tables[0].Rows.Count >= 1) //member record found
                    {
                    gvReviews.DataSource = myDS;
                    gvReviews.DataBind();

                    gvReviews.Visible = true;
                    if (gvReviews.Visible == true)
                    {
                        lblSuccessReview.Text = "";
                        lblError.Text = "";
                    }
                }
                
                     else
                    {
                    lblError.Text = "No reviews exist for this show yet! Be the first one: ";
                  }

            }
           else if (Convert.ToBoolean(Session["GameReviews"]) == true)
            {
                
                    DataSet myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));


                // myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));
                if (myDS.Tables[0].Rows.Count >= 1) //member record found
                {
                    gvReviews.DataSource = myDS;
                    gvReviews.DataBind();

                    gvReviews.Visible = true;
                    if (gvReviews.Visible == true)
                    {
                        lblSuccessReview.Text = "";
                        lblError.Text = "";
                    }
                }
                else
                {
                    lblError.Text = "No reviews exist for this game yet! Be the first one: ";
                }

            }
          
            //show delete and edit review buttons only for member's reviews
            foreach (GridViewRow row in gvReviews.Rows)
            {
                for (int i = 0; i < gvReviews.Columns.Count; i++)
                {
                    if (row.Cells[1].Text != Session["MemberAccount"].ToString())
                    {
                        row.Cells[4].Controls.Clear();
                    }
                }
            }

            //hide review IDs from user
            this.gvReviews.Columns[0].Visible = false;

        }

        protected void addReviewLink_OnClick(object sender, EventArgs e)
        {
            if (addReviewPanel.Visible == false)
            {
                addReviewPanel.Visible = true;
            }
        }
        protected void submitReview_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["MovieReviews"]) == true)
            {
                int movieID= Convert.ToInt32(Session["MovieID"]);
                int success = StoredProcedures.addMovieReview(movieID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if(success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;
                }
            }
           else if (Convert.ToBoolean(Session["GameReviews"]) == true)
            {
                int gameID = Convert.ToInt32(Session["GameID"]);
                int success = StoredProcedures.addGameReview(gameID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if (success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;
                }
            }
          else if (Convert.ToBoolean(Session["ShowReviews"]) == true)
            {
                int ShowID = Convert.ToInt32(Session["ShowID"]);
                int success = StoredProcedures.addTVShowReview(ShowID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if (success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;
                }
            }

        }
        protected void btnEditReview_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            Session["ReviewID"] = gvr.Cells[0].Text;
            Session["ReviewerName"] = gvr.Cells[1].Text;

            editReviewPanel.Visible = true;
            addReviewPanel.Visible = false;
            

        }
       protected void btnEditReviewSubmit_OnClick(object sender, EventArgs e)
        {
            //TODO: edit review. call httpput api
        }
        protected void btnDeleteReview_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            Session["ReviewID"] = gvr.Cells[0].Text;
            Session["ReviewerName"] = gvr.Cells[1].Text;

            editReviewPanel.Visible = false;
            addReviewPanel.Visible = false;
            //TODO: delete the review. call httpdelete api

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("HomePage.aspx");
        }

    }
}