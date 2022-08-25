using innorikText.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace innorikText.Controllers
{
    public class booksController : ApiController
    {
        myBookEntities1 db = new myBookEntities1();

        //add post request
 
        
        public String Post(book book)
        {
            try {
                db.books.Add(book);
                db.SaveChanges();
                return ("Data added successfull");
            }
            catch (System.IO.FileNotFoundException ex) {
                return ($"The file was not found: '{ex}'");
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return($"The directory was not found: '{ex}'");
            }
            catch (System.IO.IOException ex)
            {
                return($"The file could not be opened: '{ex}'");
            }

        }
    
        

        //get all data
        public IEnumerable<book> Get(){
            return db.books.ToList();
           
        }

        //get a specified data

        public book Get(int id)
        {
            book book = db.books.Find(id);
            return book;
        }

        //update book
        public String Put(int id, book book) {
            try {
                var _book = db.books.Find(id);
                _book.bookName = book.bookName;
                _book.category = book.category;
                _book.price = book.price;
                _book.descript = book.descript;

                db.Entry(_book).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return ("book updated successfully");

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


        //Deleting data
        public String Delete(int id)
        {
            try {
                book book = db.books.Find(id);
                db.books.Remove(book);
                db.SaveChanges();
                return ("Deleted Successfully");
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
