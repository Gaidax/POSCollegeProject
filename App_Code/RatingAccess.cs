using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

public struct RatingDetails
{
    public String oneStar;
    public String twoStars;
    public String threeStars;
    public String fourStars;
}

public struct AverageRating
{
    public string rating;
    public string rates;
}


public class RatingAccess
{

	public RatingAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static RatingDetails GetProductRatingDetails(string productId) {
        RatingDetails rating = new RatingDetails();
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getRatingDetailsList";
        comm.CommandType = CommandType.StoredProcedure;

        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        param.Value = productId;
        comm.Parameters.Add(param);

        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            rating.oneStar =(String) dr["One"];
            rating.twoStars = (String)dr["Two"];
            rating.threeStars = (String)dr["Three"];
            rating.fourStars = (String)dr["Four"];
        }


        return rating;
    }


    public static bool AddRating(String product, String user, String rate)
    {
        
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "INSERT INTO Rating VALUES ('"+product+"', '"+user+"', '"+rate+"');";
        comm.CommandType = CommandType.Text;
        try { GenericDataAccess.ExecuteNonQuery(comm); }
        catch(DbException e)
        {
            Debug.Write(e);
            comm.CommandText = "UPDATE Rating SET rating='"+rate+"' WHERE product_id='"+product+"'";
            GenericDataAccess.ExecuteNonQuery(comm);
        }
        return true;
    }

    public static AverageRating GetAverageRating(string productId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetAverageRatingList";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        param.Value = productId;
        comm.Parameters.Add(param);
        //DbParameter param2 = comm.CreateParameter();
        //param2.ParameterName = "@RES";
        //param2.Value = productId;
        //param2.DbType = DbType.Single;
        //param2.Direction = ParameterDirection.Output;
        //comm.Parameters.Add(param2);
        //comm.ExecuteNonQuery();
        // set parameter values
        //string rating = Convert.ToString(comm.Parameters["@RES"].Value);
        //string rating = GenericDataAccess.ExecuteScalar(comm);
        AverageRating ar = new AverageRating();
        DataTable dt = GenericDataAccess.ExecuteSelectCommand(comm);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            if (dr["Rating"] == DBNull.Value)
            {
                ar.rating = "-/4";
            }
            else 
            { 
                ar.rating = dr["Rating"].ToString() + "/4"; 
            }
          
            ar.rates = dr["Rates"].ToString();
        }

        return ar;
    }
}