﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;

namespace ClassLibrary
{
    public class StoredProcedures
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        //Displays all actors in database
        public DataSet getAllActors()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllActors";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getAllMovies()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllMovies";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getAllShows()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllShows";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getAllGames()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllGames";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandMovie()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomMovie";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandShow()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomShow";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandGame()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomGame";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds actors based on name typed in search bar. Uses like to find names that are similar as well.
        public DataSet getActorByName(string actorName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetActorsByName";

            SqlParameter inputParameter = new SqlParameter("@Actor_Name", actorName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds TV shows based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getShowByName(string showName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetTVShowByName";

            SqlParameter inputParameter = new SqlParameter("@Show_Name", showName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds video games based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getGameByName(string gameName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetVideoGameByName";

            SqlParameter inputParameter = new SqlParameter("@Game_Name", gameName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds movies based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getMovieByName(string movieName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMovieByName";

            SqlParameter inputParameter = new SqlParameter("@Movie_Name", movieName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        } 
        public static int verifyMemberAccount(string email)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "TP_VerifyMemberAccount";

            SqlParameter cust = new SqlParameter("@email", email);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            return objDB.DoUpdateUsingCmdObj(sqlComm);
        }
        public static int addMemberAccountRegister(string email, string firstname, string lastname, string password, string dob, string sq1, string sq2, string sq3, string sa1, string sa2, string sa3)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "TP_MemberRegister";

            SqlParameter cust = new SqlParameter("@email", email);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@firstName", firstname);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@lastName", lastname);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);





            cust = new SqlParameter("@password", password);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);
            cust = new SqlParameter("@DOB", dob);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);


            cust = new SqlParameter("@securityQ1", sq1);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA1", sq2);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityQ2", sq3);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA2", sa1);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityQ3", sa2);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA3", sa3);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            return objDB.DoUpdateUsingCmdObj(sqlComm);
        }
    }
}
