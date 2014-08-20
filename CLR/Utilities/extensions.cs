using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CLR;

namespace CLR.Utilities
{
    public static class MemberExtensions
    {
        public static List<Members> Frontiersman(this List<Members> list)
        {
            list = list.FindAll(delegate(Members m) { return m.isFrontiersman; });

            foreach (Members m in list)
            {
                m.FrontiersmanDetail = FrontierHistory.GetSingle(m.MemberID);
            }

            return list;

        }

        public static Members Frontiersman(this Members m)
        {
            m.FrontiersmanDetail = FrontierHistory.GetSingle(m.MemberID);
            return m;
        }
    }

    public static class GuestbookExentions
    {
        public static List<GuestbookComments> withDetail(this List<GuestbookComments> list)
        {
            List<Members> allMembers = Members.GetAll();
            foreach (GuestbookComments c in list) { c.Member = allMembers.Find(delegate(Members m) { return m.MemberID == c.MemberID; }); }
            return list;
        }

        public static List<GuestbookComments> Next50(this List<GuestbookComments> list, int Start)
        {
            list.Reverse();

            int end;

            if (Start + 50 > list.Count)
                end = list.Count;
            else
                end = Start + 50;

            return list.GetRange(Start, end - Start);


        }
    }
}
