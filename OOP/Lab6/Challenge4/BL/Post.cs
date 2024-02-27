using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    internal class Post
    {
        private string Title;
        private string Description;
        private int Likes;
        private List<string> Comments;
        public Post(string Title, string Description)
        {
            this.Title = Title;
            this.Description = Description;
            this.Likes = 0;
            this.Comments = new List<string>();
        }
        // Getters Setters
        public string GetTitle()
        {
            return this.Title;
        }
        public void SetTitle(string Title)
        {
            this.Title = Title;
        }
        public string GetDescription()
        {
            return this.Description;
        }
        public void SetDescription(string Description)
        {
            this.Description = Description;
        }
        public int GetLikes()
        {
            return this.Likes;
        }
        public void SetLikes(int Likes)
        {
            this.Likes = Likes;
        }
        public List<string> GetComments()
        {
            return this.Comments;
        }
        public void SetComments(List<string> Comments)
        {
            this.Comments = Comments;
        }
        // Methods
        public void Like()
        {
            this.Likes++;
        }
        public void Unlike()
        {
            this.Likes--;
        }
        public void AddComment(string Comment)
        {
            this.Comments.Add(Comment);
        }
        public void RemoveComment(string Comment)
        {
            this.Comments.Remove(Comment);
        }

    }
}
