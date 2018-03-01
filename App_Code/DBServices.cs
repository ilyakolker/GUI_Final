using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
    string connectionString = WebConfigurationManager.ConnectionStrings["Test1DB"].ConnectionString;
    SqlCommand cmd;
    SqlConnection con;
    SqlDataReader reader;
    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// NOT IMPLEMENTED CURRECTLY - NOT USING HASH AND SALT!!
    /// Checkes if email and password combination exists in the database
    /// </summary>
    /// <param name="email">the email address for login</param>
    /// <param name="password">the password for login</param>
    /// <returns>User if true, null if false</returns>
    public User Login(string email, string password)
    {
        return null;
    }
    /// <summary>
    /// Gets all users from the database 
    /// </summary>
    /// <returns>List of all users</returns>
    public List<User> GetAllUsers()
    {
        string cmdStr = "select * from users";
        SqlConnection con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        try
        {
            
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                int id = (int)reader["uId"];
                string fName = reader["firstName"].ToString();
                string mName = reader["middleName"].ToString();
                string lName = reader["lastName"].ToString();
                string degree = reader["degree"].ToString();
                string imgPath = reader["imgPath"].ToString();
                DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
                DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
                bool administrator = Convert.ToBoolean(reader["administrator"]);
                string email = reader["email"].ToString();
                string summery = reader["summery"].ToString();


                users.Add(new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator));
            }
            return users;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetAllUsers", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a specific user from the database by the user id
    /// </summary>
    /// <param name="id">id of the user</param>
    /// <returns>The user with the wanted id</returns>
    public User GetUserById(int id)
    {
        string cmdStr = "select top(1) * from users where uId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {

            
            string fName = reader["firstName"].ToString();
            string mName = reader["middleName"].ToString();
            string lName = reader["lastName"].ToString();
            string degree = reader["degree"].ToString();
            string imgPath = reader["imgPath"].ToString();
            DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
            DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
            bool administrator = Convert.ToBoolean(reader["administrator"]);
            string email = reader["email"].ToString();
            string summery = reader["summery"].ToString();


            return new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator);
            }
            return null;
        }
        catch (Exception ex)
        {
           // LogManager.Logerror("DBServices", "GetUserById(" + id + ")", ex.Message);
            return null;

        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a specific user from the database by email address
    /// </summary>
    /// <param name="email">email address of the user</param>
    /// <returns>The user with the wanted email</returns>
    public User GetUserByEmail(string email)
    {
        string cmdStr = "select top(1) * from users where email= @email";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@email", email);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["uId"];
                string fName = reader["firstName"].ToString();
                string mName = reader["middleName"].ToString();
                string lName = reader["lastName"].ToString();
                string degree = reader["degree"].ToString();
                string imgPath = reader["imgPath"].ToString();
                DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
                DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
                bool administrator = Convert.ToBoolean(reader["administrator"]);
                string summery = reader["summery"].ToString();
                return new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator);
            }
            return null;
        }
        catch (Exception ex)
        {
           // LogManager.Logerror("DBServices", "GetUserByEmail(" + email + ")", ex.Message);
            return null;

        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the clusters of a specific user by the user id
    /// </summary>
    /// <param name="uId">id of the user</param>
    /// <returns>All Clusters associated with this user</returns>
    public List<Cluster> GetUserClusters(int uId)
    {
        string cmdStr = "select * from v_UserClusters where uId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", uId);
        try
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cluster> clusters = new List<Cluster>();
            while (reader.Read())
            {
                int cId = (int)reader["cId"];
                string name = reader["cName"].ToString();
                clusters.Add(new Cluster(cId, name));
            }
            return clusters;

        }
        catch (Exception ex)
        {
           // LogManager.Logerror("DBServices", "GetUserClusters(" + uId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the articles for a specific user by user id
    /// </summary>
    /// <param name="uId">the user id</param>
    /// <returns>all articles published by this user</returns>
    public List<Article> GetUserArticles(int uId)
    {
        string cmdStr = "select * from v_UserArticles where uId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", uId);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Article> articles = new List<Article>();
            while (reader.Read())
            {
                int aId = (int)reader["aId"];
                string title = reader["title"].ToString();
                string link = reader["aLink"].ToString();
                articles.Add(new Article(aId, title, link));
            }
            return articles;

        }
        catch (Exception ex)
        {
           // LogManager.Logerror("DBServices", "GetUserArticles(" + uId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the academic institutional affiliations for a specific user 
    /// by the user id
    /// </summary>
    /// <param name="uId">the user id</param>
    /// <returns>all institutes affiliated with the user</returns>
    public List<Institute> GetUserAffiliations(int uId)
    {
        string cmdStr = "select * from v_UserAffiliations where uId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", uId);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Institute> institutes = new List<Institute>();
            while (reader.Read())
            {
                int iId = (int)reader["iId"];
                string name = reader["iName"].ToString();
                institutes.Add(new Institute(iId, name));
            }
            return institutes;

        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetUserAffiliations(" + uId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the clusters from the database
    /// </summary>
    /// <returns>All Clusters</returns>
    public List<Cluster> GetAllClusters()
    {
        string cmdStr = "select * from clusters";
        SqlConnection con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cluster> clusters = new List<Cluster>();
            while (reader.Read())
            {
                int id = (int)reader["cId"];
                string name = reader["cName"].ToString();
                clusters.Add(new Cluster(id, name));
            }
            return clusters;
        }
        catch (Exception ex)
        {
            // LogManager.Logerror("DBServices", "GetAllClusters", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a cluster by the cluster id
    /// </summary>
    /// <param name="id">the cluster id</param>
    /// <returns>the cluster with the wanted id </returns>
    public Cluster GetClusterById(int id)
    {
        string cmdStr = "select top(1) * from Clusters where cId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["cName"].ToString();
                return new Cluster(id, name);
            }
            return null;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetClusterById(" + id + ")", ex.Message);
            return null;

        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all keywords in a specific cluster by the cluster id
    /// </summary>
    /// <param name="cId">Cluster id</param>
    /// <returns>All keywords associated with the cluster id</returns>
    public List<Keyword> GetClusterKeywords(int cId)
    {
        string cmdStr = "select * from v_ClusterKeywords where cId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", cId);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            List<Keyword> keywords = new List<Keyword>();
            while (reader.Read())
            {
                int kId = (int)reader["kId"];
                string phrase = reader["phrase"].ToString();
                keywords.Add(new Keyword(kId, phrase));
            }
            return keywords;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetClusterKeywords(" + cId+ ")", ex.Message);
            return null;
        } finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the users of a specific cluster by cluster id
    /// </summary>
    /// <param name="cId">id of the cluster</param>
    /// <returns>All users associated with this cluster</returns>
    public List<User> GetClusterUsers(int cId)
    {
        string cmdStr = "select * from v_UserClusters where cId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", cId);
        try
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                int id = (int)reader["uId"];
                string fName = reader["firstName"].ToString();
                string mName = reader["middleName"].ToString();
                string lName = reader["lastName"].ToString();
                string degree = reader["degree"].ToString();
                string imgPath = reader["imgPath"].ToString();
                DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
                DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
                bool administrator = Convert.ToBoolean(reader["administrator"]);
                string email = reader["email"].ToString();
                string summery = reader["summery"].ToString();


                users.Add(new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator));
            }
            return users;

        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetUserClusters(" + cId + ")", ex.Message);
            return null;
        }finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the articles from the database
    /// </summary>
    /// <returns></returns>
    public List<Article> GetAllArticles()
    {
        string cmdStr = "select * from articles";
        SqlConnection con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Article> articles = new List<Article>();
            while (reader.Read())
            {
                int id = (int)reader["aId"];
                string title = reader["title"].ToString();
                string link = reader["aLink"].ToString();
                articles.Add(new Article(id, title, link));
            }
            return articles;
        }
        catch (Exception ex)
        {
            // LogManager.Logerror("DBServices", "GetAllArticles", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a specific article by the article id
    /// </summary>
    /// <param name="id">The article id</param>
    /// <returns>The article with the wanted id</returns>
    public Article GetArticleById(int id)
    {
        string cmdStr = "select top(1) * from Articles where aId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string title = reader["title"].ToString();
                string link = reader["aLink"].ToString();
                return new Article(id, title, link);
            }
            return null;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetArticleById(" + id + ")", ex.Message);
            return null;

        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the users in this article by article id
    /// </summary>
    /// <param name="aId">The article id</param>
    /// <returns>All users associated with this article</returns>
    public List<User> GetArticleUsers(int aId)
    {
        string cmdStr = "select * from v_UserArticles where aId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", aId);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                int id = (int)reader["uId"];
                string fName = reader["firstName"].ToString();
                string mName = reader["middleName"].ToString();
                string lName = reader["lastName"].ToString();
                string degree = reader["degree"].ToString();
                string imgPath = reader["imgPath"].ToString();
                DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
                DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
                bool administrator = Convert.ToBoolean(reader["administrator"]);
                string email = reader["email"].ToString();
                string summery = reader["summery"].ToString();


                users.Add(new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator));
            }
            return users;
        }
        catch (Exception ex)
        {

            //LogManager.Logerror("DBServices", "GetArticleUsers(" + aId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the keywords for a specific article by the article id
    /// </summary>
    /// <param name="aId">the article id </param>
    /// <returns>All keywords associated with this article</returns>
    public List<Keyword> GetArticleKeywords(int aId)
    {
        string cmdStr = "select * from v_ArticleKeywords where aId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", aId);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            List<Keyword> keywords = new List<Keyword>();
            while (reader.Read())
            {
                int id = (int)reader["aId"];
                string phrase = reader["phrase"].ToString();
                keywords.Add(new Keyword(id, phrase));
            }
            return keywords;
        }
        catch (Exception ex)
        {

            //LogManager.Logerror("DBServices", "GetKeywordArticles(" + aId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all Keywords from the database
    /// </summary>
    /// <returns></returns>
    public List<Keyword> GetAllKeywords()
    {
        string cmdStr = "select * from Keywords";
        SqlConnection con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Keyword> keywords = new List<Keyword>();
            while (reader.Read())
            {
                int id = (int)reader["iId"];
                string name = reader["iName"].ToString();
                keywords.Add(new Keyword(id, name));
            }
            return keywords;
        }
        catch (Exception ex)
        {
            // LogManager.Logerror("DBServices", "GetAllKeywords", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a specific keyword by the keyword id
    /// </summary>
    /// <param name="id">The keyword id</param>
    /// <returns>The keyword with the wanted id</returns>
    public Keyword GetKeywordById(int id)
    {
        string cmdStr = "select top(1) * from Keywords where kId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string phrase = reader["phrase"].ToString();
                return new Keyword(id, phrase);
            }
            return null;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetKeywordById(" + id + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the clusters with a specific keyword using keyword id
    /// </summary>
    /// <param name="kId">the id of the keyword</param>
    /// <returns>All clusters associated with this keyword</returns>
    public List<Cluster> GetKeywordClusters(int kId)
    {
        string cmdStr = "select * from v_ClusterKeywords where kId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", kId);
        try
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cluster> clusters = new List<Cluster>();
            while (reader.Read())
            {

                int cId = (int)reader["cId"];
                string name = reader["name"].ToString();
                clusters.Add(new Cluster(cId, name));
            }
            return clusters;

        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetKeywordClusters(" + kId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all Academic Institutes from the database
    /// </summary>
    /// <returns>All Institutes</returns>
    public List<Institute> GetAllInstitutes()
    {
        string cmdStr = "select * from AcademicInstitutes";
        SqlConnection con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Institute> institutes = new List<Institute>();
            while (reader.Read())
            {
                int id = (int)reader["iId"];
                string name = reader["iName"].ToString();
                institutes.Add(new Institute(id, name));
            }
            return institutes;
        }
        catch (Exception ex)
        {
            // LogManager.Logerror("DBServices", "GetAllInstitutes", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets a specific academic institute by the institute id
    /// </summary>
    /// <param name="id">The institute id</param>
    /// <returns>The academic institute associated with the provided</returns>
    public Institute GetInstituteById(int id)
    {
        string cmdStr = "select top(1) * from [AcademicInstitutes] where iId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", id);
        try
        {
            cmd.Connection.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string phrase = reader["iName"].ToString();
                return new Institute(id, phrase);
            }
            return null;
        }
        catch (Exception ex)
        {
            //LogManager.Logerror("DBServices", "GetInstituteById(" + id + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    /// <summary>
    /// Gets all the users in a specific academic institute by the institute id
    /// </summary>
    /// <param name="iId">Theinsitute id</param>
    /// <returns>All the users associated with the provided institute id</returns>
    public List<User> GetInstituteUsers(int iId)
    {
        string cmdStr = "select * from v_InstituteUsers where iId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", iId);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                int id = (int)reader["uId"];
                string fName = reader["firstName"].ToString();
                string mName = reader["middleName"].ToString();
                string lName = reader["lastName"].ToString();
                string degree = reader["degree"].ToString();
                string imgPath = reader["imgPath"].ToString();
                DateTime birthDate = reader["birthDate"] == null ? Convert.ToDateTime(reader["birthDate"]) : DateTime.MinValue;
                DateTime registrationDate = reader["registrationDate"] == null ? Convert.ToDateTime(reader["registrationDate"]) : DateTime.MinValue;
                bool administrator = Convert.ToBoolean(reader["administrator"]);
                string email = reader["email"].ToString();
                string summery = reader["summery"].ToString();


                users.Add(new User(id, fName, mName, lName, imgPath, degree, email, summery, administrator));
            }
            return users;
        }
        catch (Exception ex)
        {

            //LogManager.Logerror("DBServices", "GetInstituteUsers(" + iId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }
    public List<Article> GetKeywordArticles(int kId)
    {
        string cmdStr = "select * from v_ArticleKeywords where kId = @id";
        con = new SqlConnection(connectionString);
        cmd = new SqlCommand(cmdStr, con);
        cmd.Parameters.AddWithValue("@id", kId);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
            List<Article> articles = new List<Article>();
            while (reader.Read())
            {
                int id = (int)reader["aId"];
                string title = reader["title"].ToString();
                string link = reader["aLink"].ToString();
                articles.Add(new Article(id, title, link));
            }
            return articles;
        }
        catch (Exception ex)
        {

            //LogManager.Logerror("DBServices", "GetKeywordArticles(" + kId + ")", ex.Message);
            return null;
        }
        finally
        {
            cmd.Connection.Close();
        }
    }

   

}