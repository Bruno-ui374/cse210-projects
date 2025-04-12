using System;
using System.Collections.Generic;

namespace YouTubeProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            List<Video> videos = new List<Video>();

            
            Video video1 = new Video("Learning C#", "John Doe", 600);
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "This really helped me understand the concept."));
            video1.AddComment(new Comment("Charlie", "Looking forward to more videos."));
            videos.Add(video1);

        
            Video video2 = new Video("Intro to Java", "Jane Smith", 750);
            video2.AddComment(new Comment("Dave", "Very informative."));
            video2.AddComment(new Comment("Eve", "Nice pace and clear presentation."));
            video2.AddComment(new Comment("Frank", "Keep up the good work!"));
            videos.Add(video2);

       
            Video video3 = new Video("Python Programming", "Alex Johnson", 900);
            video3.AddComment(new Comment("Grace", "Python is my favorite language!"));
            video3.AddComment(new Comment("Heidi", "Well done, very easy to understand."));
            video3.AddComment(new Comment("Ivan", "Thanks for the tips."));
            videos.Add(video3);

   
            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}
