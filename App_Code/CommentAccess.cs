using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentAccess
/// </summary>
public class CommentAccess
{
    public CommentAccess()
    {
    }
		public static void addComment(string comment, string product, string user) {

            DbCommand comm = GenericDataAccess.CreateCommand();
            DbCommand comm2 = GenericDataAccess.CreateCommand();
            comm2.CommandText = "Select id from Comment";
            comm2.CommandType = CommandType.Text;
            DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm2);
            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
            int id = (Int32)lastRow["id"];
            id++;
            string lastID = id.ToString();
            comm.CommandText = "INSERT INTO Comment VALUES ('" + lastID + "' ,'" + user + "', '" + product + "', '" + comment + "');";
            comm.CommandType = CommandType.Text;
            GenericDataAccess.ExecuteNonQuery(comm); 
        }

        public static bool deleteRating(string id, string client)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "DELETE from Comment where id='"+id+"' and client_id='"+client+"'";
            comm.CommandType = CommandType.Text;
            try
            {
                GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                return false;
            }

            return true;
        }
	
}