namespace YouTubeVideoProgram
{
    public class Comment
    {
        // Private member variables using underscoreCamelCase.
        private string _commenterName;
        private string _commentText;

        // Constructor of comment object.
        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        // Public read-only properties.
        public string CommenterName
        {
            get { return _commenterName; }
        }

        public string CommentText
        {
            get { return _commentText; }
        }
    }
}
