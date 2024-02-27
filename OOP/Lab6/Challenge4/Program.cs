using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserM user1 = new UserM("John");
            UserM user2 = new UserM("Jane");
            Post post1 = new Post("Photo", "ABCD");
            Post post2 = new Post("Video", "EFGH");
            user1.AddPost(post1);
            user1.AddPost(post2);
            user1.FollowMe(user2);
            user2.FollowMe(user1);
            user1.LikePost(post1);
            user1.LikePost(post1);
            user1.LikePost(post2);
            user1.UnlikePost(post2);
            user1.AddCommentToPost(post1, "Nice");
            user1.AddCommentToPost(post1, "Like it");
            user1.RemoveCommentFromPost(post1, "Nice");
            user1.EditCommentFromPost(post1, "Like it", "Good");
            user1.ShowPosts();
            user1.ShowPost(post1);
            user1.ShowPost(post2);
        }
    }
}
