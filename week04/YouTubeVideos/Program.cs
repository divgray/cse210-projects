using System;

class Program
{
    static void Main(string[] args)
    {
        // List to hold video objects.
        var videos = new List<Video>();

        // Video 1 and adding Comments.
        var video1 = new Video("Learning C#", "Anna", 300);
        video1.AddComment(new Comment("Baily", "Great tutorial!"));
        video1.AddComment(new Comment("Cathy", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Diana", "Can't wait to try this out."));
        videos.Add(video1);

        // Video 2 and adding Comments.
        var video2 = new Video("Web Development", "Bobby", 450);
        video2.AddComment(new Comment("Annie", "Excellent video."));
        video2.AddComment(new Comment("Billy", "I learned a lot."));
        video2.AddComment(new Comment("Cris", "This was very clear."));
        video2.AddComment(new Comment("Dan", "Thank you needed this."));
        videos.Add(video2);

        // Video 3 and adding Comments.
        var video3 = new Video("Introduction to Programming", "Carole", 600);
        video3.AddComment(new Comment("Eman", "Nice explanation!"));
        video3.AddComment(new Comment("Frank", "Well done."));
        video3.AddComment(new Comment("George", "I appreciate the simplicity."));
        video3.AddComment(new Comment("Hannah", "Can you add other examples?"));
        videos.Add(video3);

        // Optional: Video 4 and adding Comments.
        var video4 = new Video("Design Patterns in C#", "Daniel", 480);
        video4.AddComment(new Comment("Oscar", "Very informative."));
        video4.AddComment(new Comment("Pampam", "Loved the examples."));
        video4.AddComment(new Comment("Queen", "Keep up the good work."));
        videos.Add(video4);

        // Iterate over each video and display the details.
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.Length);
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}

// Video classs
public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // in seconds


    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
