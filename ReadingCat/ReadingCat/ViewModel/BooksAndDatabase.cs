using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReadingCat.Models;

namespace ReadingCat.ViewModel
{
    public class BooksAndDatabase
    {
        public BooksAndDatabase()
        {
            databaseModel = new DatabaseModel();
            listOfBooks = new List<List<Books>>();
            initializeList();
        }
        public DatabaseModel databaseModel { get; set; }

        public List<List<Books>> listOfBooks { get; set; }
        public List<Books> library { get; set; }
        public List<Books> publishedStories { get; set; }
        public List<Books> recommendation { get; set; }

        private void initializeList()
        {
            library = new List<Books>();
            publishedStories = new List<Books>();
            recommendation = new List<Books>();

            for(int i=0;i<3;i++)
            {
                //listOfBooks[i] = new List<Books>();
                listOfBooks.Add(new List<Books>());
            }

            listOfBooks[0] = library;
            listOfBooks[1] = publishedStories;
            listOfBooks[2] = recommendation;
        }

    }
}