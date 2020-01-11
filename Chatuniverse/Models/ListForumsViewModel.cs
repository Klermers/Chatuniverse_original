using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic;

namespace Chatuniverse.Models
{
    public class ListForumsViewModel
    {
        public List<ForumViewModel> ForumList
        {
            get;
            set;
        }

        public ListForumsViewModel(List<ForumViewModel> forumviewmodels)
        {
            ForumList = forumviewmodels;
        }
    }
}
