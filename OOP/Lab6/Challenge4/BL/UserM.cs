using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    internal class UserM
    {
        
            private string Name;
            private string Password;
            private List<Post> Posts;
            private List<UserM> Followers;
            public UserM(string Name)
            {
                this.Name = Name;
                this.Posts = new List<Post>();
                Followers = new List<UserM>();
            }
            // Getters Setters
            public string GetName()
            {
                return this.Name;
            }
            public void SetName(string Name)
            {
                this.Name = Name;
            }
            
            public List<Post> GetPosts()
            {
                return this.Posts;
            }
            public void SetPosts(List<Post> Posts)
            {
                this.Posts = Posts;
            }
            public List<UserM> GetFollowers()
            {
                return this.Followers;
            }
            public void SetFollowers(List<UserM> Followers)
            {
                this.Followers = Followers;
            }
          
            public void AddPost(Post Post)
            {
                this.Posts.Add(Post);
            }
            public void RemovePost(Post Post)
            {
                this.Posts.Remove(Post);
            }
            public void EditPost(Post Post, string Title, string Description)
            {
                Post.SetTitle(Title);
                Post.SetDescription(Description);
            }
            public void LikePost(Post Post)
            {
                Post.Like();
            }
            public void UnlikePost(Post Post)
            {
                Post.Unlike();
            }
            public void AddCommentToPost(Post Post, string Comment)
            {
                Post.AddComment(Comment);
            }
            public void RemoveCommentFromPost(Post Post, string Comment)
            {
                Post.GetComments().Remove(Comment);
            }
            public void EditCommentFromPost(Post Post, string OldComment, string NewComment)
            {
                Post.GetComments().Remove(OldComment);
                Post.GetComments().Add(NewComment);
            }
            public void ShowPosts()
            {
                foreach (Post post in this.Posts)
                {
                    ShowPost(post);
                }
            }
            public void ShowPost(Post Post)
            {
                Console.WriteLine(Post.GetTitle());
                Console.WriteLine(Post.GetDescription());
                Console.WriteLine(Post.GetLikes());
                foreach (string comment in Post.GetComments())
                {
                    Console.WriteLine(comment);
                    Console.WriteLine("      ");
                }
            }
            public void FollowMe(UserM User)
            {
                this.Followers.Add(User);
            }
            public void UnfollowMe(UserM User)
            {
                this.Followers.Remove(User);
            }
        }
    
}
