using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public struct Name
    {
        private string fname,lname,mname;

        public Name(string fname,string mname,string lname)
        {
            this.fname = fname;
            this.lname = lname;
            this.mname = mname;
        }

        public string first_name {
            get { return fname; }
            set { fname = first_name; }
        }

        public string last_name
        {
            get { return lname; }
            set { lname = last_name; }
        }

        public string middle_name
        {
            get { return mname; }
            set { mname = middle_name; }
        }

        public override string ToString()
        {
            return (string.Format("{0}{1}{2}",fname+" ",mname+" ",lname));
        }



    }
}
