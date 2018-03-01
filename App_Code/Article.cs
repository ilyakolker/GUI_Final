using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Article
/// </summary>
public class Article
{
    DBServices db;
    int id;
    string title, link;
    List<User> users;
    List<Keyword> keywords;


    public int Id { get { return id; } }
    public string Title { get { return title; } }
    public string Link { get { return link; } }
    



    public Article()
    {
     
        db = new DBServices();
    }

    public Article(int id, string title, string link) 
    {

        db = new DBServices();
        this.id = id;
        this.title = title;
        this.link = link;
    }

    public List<Article> GetAllArticles()
    {
        return db.GetAllArticles();
    }
    public Article GetArticleById(int aId)
    {
        return db.GetArticleById(aId);
    }

    public List<Keyword> GetArticleKeywordsById(int aId)
    {
        return db.GetArticleKeywords(aId);
    }
    public List<User> GetArticleUsersById(int uId)
    {
        return db.GetArticleUsers(uId);

    }

    public override string ToString()
    {
        string info = "Id: " + id + "<br>";

        info += "Title: " + title + "<br>";
        info += "Link: " + link + "<br>";

        return info;
    }

    public List<User> Users()
    {
        return users;
    }
    public List<Keyword> Keywords()
    {
        return keywords;
    }
}