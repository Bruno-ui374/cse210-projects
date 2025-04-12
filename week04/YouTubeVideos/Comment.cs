using System;

namespace YouTubeProgram
{
    public class Comment
    {
        private string _commenterName;
        private string _commentText;

        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        // Displays a single comment.
        public void DisplayComment()
        {
            Console.WriteLine(" - " + _commenterName + ": " + _commentText);
        }
    }
}
