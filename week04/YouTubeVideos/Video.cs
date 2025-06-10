using System.Collections.Generic;

namespace YouTubeVideoProgram
{
    public class Video
    {
        // Encapsulation type
        private string _title;
        private string _author;
        private int _length; // in seconds
        private List<Comment> _comments;

        // Constructor to initialize the Video object.
        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
            _comments = new List<Comment>();
        }

        // Public read-only properties.
        public string Title
        {
            get { return _title; }
        }

        public string Author
        {
            get { return _author; }
        }

        public int Length
        {
            get { return _length; }
        }

        // Exposes the list of comments.
        public List<Comment> Comments
        {
            get { return _comments; }
        }

        // Adds a comment to the Video.
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Returns the number of comments stored.
        public int GetCommentCount()
        {
            return _comments.Count;
        }
    }
}
