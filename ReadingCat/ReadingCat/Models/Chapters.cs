﻿
namespace ReadingCat.Models
{
    public class Chapters
    {
        public int chapterId { get; set; }
        public string chapterName { get; set; }
        public string chatpterText { get; set; }
        public int approved { get; set; }

        public int bookId { get; set; }

    }
}