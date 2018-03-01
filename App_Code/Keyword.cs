using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Keywords
/// </summary>
public class Keyword
{
    //Fields:
    DBServices db;
    int id;
    string phrase;
    List<Cluster> clusters;
    List<Article> articles;

    //Props:
    public int Id { get { return id; } }
    public string Phrase { get { return phrase; } }
  


    //Ctors
    public Keyword()
    {

        db = new DBServices();
    }

    public Keyword(int id, string phrase)
    {
        db = new DBServices();
        this.id = id;
        this.phrase = phrase;
    }

    //Methods
    public List<Keyword> GetAllKeywords()
    {
        return db.GetAllKeywords();
    }
    public Keyword GetKeywordById(int kId)
    {
        return db.GetKeywordById(kId);
    }
    public List<Cluster> GetKeywordClustersById(int kId)
    {
        return db.GetKeywordClusters(kId);
    }
    public override string ToString()
    {
        string info = "ID: " + id + "<br>";
        info += "Pharse: " + "<br>";
        return info;
    }
    public List<Cluster> Clusters()
    {
        return clusters;
    }
    public List<Article> Articles()
    {
        return articles;
    }
}