using System;
using System.Collections.Generic;

namespace YouTubeVideoProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to hold video objects.
            List<Video> videos = new List<Video>();

            // Video 1.
            Video video1 = new Video("Programming with Classes", "Waldyr Junior", 300);
            video1.AddComment(new Comment("Baily Haily", "Great tutorial!"));
            video1.AddComment(new Comment("Cathy Jane", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Diana Kruger", "Can't wait to try this out."));
            videos.Add(video1);

            // Video 2.
            Video video2 = new Video("Web Front End Developer 1", "Clint Kunz", 450);
            video2.AddComment(new Comment("Annie Lockhart", "Excellent video."));
            video2.AddComment(new Comment("Billy Jones", "I learned a lot."));
            video2.AddComment(new Comment("Cris Patt", "This was very clear."));
            video2.AddComment(new Comment("Dan Delion", "Thank you needed this."));
            videos.Add(video2);

            // Video 3.
            Video video3 = new Video("Jesus Christ and His Everlasting Gospel B", "Carole", 600);
            video3.AddComment(new Comment("Eman Hurt", "Nice explanation!"));
            video3.AddComment(new Comment("Frank Castle", "Well done."));
            video3.AddComment(new Comment("George Tim", "I appreciate the simplicity."));
            video3.AddComment(new Comment("Hannah Montana", "Can you add other examples?"));
            videos.Add(video3);

            // Display details.
            foreach (Video video in videos)
            {
                Console.WriteLine();
                Console.WriteLine("Title: " + video.Title);
                Console.WriteLine("Author: " + video.Author);
                Console.WriteLine("Length (seconds): " + video.Length);
                Console.WriteLine("Number of Comments: " + video.GetCommentCount());
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine("  - " + comment.CommenterName + ": " + comment.CommentText);
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
