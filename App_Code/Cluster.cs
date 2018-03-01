using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cluster
/// </summary>
public class Cluster
{
    //Utility:
    DBServices db;

    //Fields:
    int id;
    string name;
    List<Keyword> keywords;
    List<User> users;


    //Properties:
    public int Id { get { return id; } }
    public string Name { get { return name; } }
  


    //Constructors:
    public Cluster()
    {
        db = new DBServices();
    }

    public Cluster(int id, string name) 
    {
        db = new DBServices();
        this.id = id;
        this.name = name;
        keywords = db.GetClusterKeywords(id);
        users = db.GetClusterUsers(id);
    }

    //Methods:
    public List<Cluster> GetAllClusters()
    {
        return db.GetAllClusters();
    }

    public Cluster GetClusterById(int _id)
    {
        return db.GetClusterById(_id);
    }
    public List<User> GetClusterUsersById(int cId)
    {
        return db.GetClusterUsers(cId);
    }
   
    public List<Keyword> GetClusterKeywordsById(int cId)
    {
        return db.GetClusterKeywords(cId);
    }

    public override string ToString()
    {
        string info = "ID: " + id + "<br>";
        info += "Name: " + name + "<br>";

        return base.ToString();
    }
    public List<Keyword> Keywords()
    {
        return keywords;
    }

    public List<User> Users()
    {

        return users;

    }
}