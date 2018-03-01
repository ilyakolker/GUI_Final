using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestingRemovable
/// </summary>
public class TestingRemovable
{
    int id;
    string fName, mName, lName;
    string imgPath, degree, hash, salt, email, summery;
    bool administrator;
    DateTime bdate, registrationDate;

    public TestingRemovable(int id, string fName, string mName, string lName, string imgPath, string degree,  string email, string summery, bool administrator, DateTime bdate, DateTime registrationDate)
    {
        this.id = id;
        this.fName = fName;
        this.mName = mName;
        this.lName = lName;
        this.imgPath = imgPath;
        this.degree = degree;

        this.email = email;
        this.summery = summery;
        this.administrator = administrator;
        this.bdate = bdate;
        this.registrationDate = registrationDate;
    }
}