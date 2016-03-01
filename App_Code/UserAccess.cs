using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccess
/// </summary>
/// 

public struct  Client
{
    public string id;
    public string firstName;
    public string lastName;
}

public class UserAccess
{
	public UserAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Client LoginClient(String login, String password) {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "Select id, First_Name, Last_Name from Client where login ='"+login+"' and password= '"+password+"';";
        comm.CommandType = CommandType.Text;
        Client cl = new Client();
        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];              
            cl.id = dr["id"].ToString();
            cl.firstName = dr["First_Name"].ToString();
            cl.lastName = dr["Last_Name"].ToString();
        }
        return cl;
    }

}