using System;
using System.Collections.Generic;
using System.Text;

namespace ChatUniverseInterface
{
    public interface IComment
    {
        void CreateComment(string comment, int postid, int userid);

        void UpdateComment_Comment(int commentid, string comment);

        void DeleteComment(int id);
    }
}
