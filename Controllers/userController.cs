using innorikText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innorikText.Controllers
{
    public class userController : ApiController
    {
        myUserEntities db = new myUserEntities();

        //add post request
        public String Post(myUser myUser)
        {
            try
            {
                db.myUsers.Add(myUser);
                db.SaveChanges();
                return ("User added successfull");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return ($"The file was not found: '{ex}'");
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return ($"The directory was not found: '{ex}'");
            }
            catch (System.IO.IOException ex)
            {
                return ($"The file could not be opened: '{ex}'");
            }
        }

        //get all data
        public IEnumerable<myUser> Get()
        {
            return db.myUsers.ToList();

        }

        //get a specified data

        public myUser Get(int id)
        {
            myUser myUser = db.myUsers.Find(id);
            return myUser;
        }

        //update book
       public String Put(int id, myUser myUser)
        {
            try {
                var _myUser = db.myUsers.Find(id);
                _myUser.userName = myUser.userName;
                _myUser.userPassword = myUser.userPassword;
                db.Entry(_myUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return ("User updated successfully");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return ($"The file was not found: '{ex}'");
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return ($"The directory was not found: '{ex}'");
            }
            catch (System.IO.IOException ex)
            {
                return ($"The file could not be opened: '{ex}'");
            }
      }
   


        //Delete data
       public String Delete(int id)
        {
            try {
                myUser myUser = db.myUsers.Find(id);
                db.myUsers.Remove(myUser);
                db.SaveChanges();
                return ("User Deleted Successfully");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return ($"The file was not found: '{ex}'");
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return ($"The directory was not found: '{ex}'");
            }
            catch (System.IO.IOException ex)
            {
                return ($"The file could not be opened: '{ex}'");
            }


        }
    
}
}
