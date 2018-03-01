using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class User
{
    //Utility:
    private DBServices db;

    //Fields:
    int id;
    string fName, mName, lName;
    string imgPath, degree, hash, salt, email, summery;
    bool administrator;
    DateTime bdate, registrationDate;
    List<Article> articles;
    List<Institute> affiliations;
    List<Cluster> clusters;

    //Properties:
    public int Id { get { return id; } }
    public string Name { get { return string.Format("{0} {1} {2}", fName, mName, lName); } }
    public string ImgPath { get { return imgPath; } }
    public bool IsAdmin { get { return administrator; } }
    public string Email { get { return email; } }
    public string Summery { get { return summery; } }
    public DateTime BirthDate { get { return bdate; } }
    public DateTime RegistrationDate { get { return registrationDate; } }

    public List<Article> Articles
    {
        get
        {
            if (articles==null)
            {
                articles = db.GetUserArticles(id);
               
            }
            return articles;
        }
    }


    //Constructors:
    public User()
    {
        db = new DBServices();
    }
    public User(int id, string fName, string mName, string lName, string imgPath, string degree, string email, string summery, bool administrator)
    {
        db = new DBServices();
        this.id = id;
        this.fName = fName;
        this.mName = mName;
        this.lName = lName;
        this.imgPath = imgPath;
        this.degree = degree;
        this.email = email;
        this.summery = summery;
        this.administrator = administrator;

    }


    //Methods:
    public User Login(string email, string password)
    {
        return db.Login(email, password);
    }
    public User GetUserById(int id)
    {
        return db.GetUserById(id);
    }
    public User GetUserByEmail(string email)
    {
        return db.GetUserByEmail(email);
    }


    public List<User> GetAllUsers()
    {
        return db.GetAllUsers();

    }
    public override string ToString()
    {
        string info = "id: " + id + "<br>";
        info += "Name: " + Name + "<br>";
        info += "Image: " + imgPath + "<br>";
        info += "Admin: " + IsAdmin + "<br>";
        info += "Email: " + Email + "<br>";
        info += "Summery: " + Summery + "<br>";
        info += "Birth Date: " + bdate + "<br>";
        info += "Registration Date: " + registrationDate + "<br>";



        return info;
    }


    //public List<Article> GetArticles()
    //{        
    //    return articles;
    //}
    public List<Cluster> GetClusters()
    {
        return clusters;
    }
    public List<Institute> GetAffiliations()
    {
        return affiliations;
    }

}