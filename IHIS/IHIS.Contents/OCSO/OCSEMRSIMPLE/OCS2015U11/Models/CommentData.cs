using IHIS.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmrDocker.Models
{
    public class CommentData
    {
        private string _tagId;
        private List<CommentInfo> commentList = new List<CommentInfo>();

        public string TagId
        {
            get { return _tagId; }
            set { _tagId = value; }
        }
        public List<CommentInfo> CommentList
        {
            get { return commentList; }
        }
        public CommentData(CommentInfo commentInfo)
        {
            TagId = commentInfo.TagId;
            CommentList.Add(commentInfo);
        }
        public CommentData()
        {
            TagId = string.Empty;
            commentList = new List<CommentInfo>();
        }

        public void InsertComment(CommentInfo commentInfo)
        {
            if (GetCommentIndex(commentInfo.CommentId) < 0)
                this.CommentList.Add(commentInfo);
        }
        public void UpdateComment(CommentInfo commentInfo)
        {
            int cmmtIndex = GetCommentIndex(commentInfo.CommentId);
            if (cmmtIndex >= 0)
            {
                this.commentList[cmmtIndex].Comment = commentInfo.Comment;
                this.commentList[cmmtIndex].Title = commentInfo.Title;
            }

        }
        public int DeleteComment(string commentId)
        {
            int cmmtIndex = GetCommentIndex(commentId.Trim());
            if (cmmtIndex < 0)
                return this.CommentList.Count;
            this.CommentList.RemoveAt(cmmtIndex);
            return this.CommentList.Count;
        }

        private int GetCommentIndex(string commentId)
        {
            if (this.CommentList.Count <= 0) return -1;
            for (int i = 0; i < CommentList.Count; i++)
            {
                if (CommentList[i].CommentId.Trim().Equals(commentId.Trim()))
                    return i;
            }
            return -1;
        }

        public void ClearCommentItemByPkOut(string pkOut)
        {
            for (int i = 0; i < CommentList.Count; i++)
            {
                if (CommentList[i].Pkout.Trim().Equals(pkOut.Trim()) && CommentList[i].UserId == UserInfo.UserID)
                    DeleteComment(CommentList[i].CommentId);
            }
        }
        public void ClearCommentItemByID(string commentId)
        {
            for (int i = 0; i < CommentList.Count; i++)
            {
                if (CommentList[i].CommentId.Trim().Equals(commentId.Trim()) && CommentList[i].UserId ==  UserInfo.UserID)
                    DeleteComment(CommentList[i].CommentId);
            }
        }
        public List<CommentInfo> GetCommentsByPkout(string pkOut)
        {
            List<CommentInfo> ret = new List<CommentInfo>();
            if (string.IsNullOrEmpty(pkOut))
                return ret;
            for (int i = 0; i < CommentList.Count; i++)
            {
                if (CommentList[i].Pkout != null && !string.IsNullOrEmpty(CommentList[i].Pkout) && Convert.ToDouble(CommentList[i].Pkout.Trim()) == Convert.ToDouble(pkOut.Trim()))
                    ret.Add(CommentList[i]);
            }

            return ret;
        }

        public void DeleteCommentsByTagId(string tagId)
        {
            for (int i = 0; i < CommentList.Count; i++)
            {
                if (CommentList[i].TagId.Trim().Equals(tagId.Trim()) && CommentList[i].UserId == UserInfo.UserID)
                    DeleteComment(CommentList[i].CommentId);
            }
        }
        private void clearData()
        {
            this.CommentList.Clear();
        }
    }

    public class UpdateDataEmrAgrs : EventArgs
    {
        private List<string> _tagIds;
        private List<CommentInfo> _commentList;
        public List<string> TagIds
        {
            get { return _tagIds; } 
        }

        public List<CommentInfo> CommentList
        {
            get { return _commentList; }
        }
        public UpdateDataEmrAgrs(List<string> tagIds, List<CommentInfo> commentList)
        {
            _tagIds = tagIds;
            _commentList = commentList;
        }
    }
}
