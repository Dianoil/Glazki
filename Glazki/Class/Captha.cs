using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glazki.Class
{
    public class Captha
    {
        public string Capthat
        {
            get
            {
                Random random = new Random();
                String alr = "";
                alr = "Q,W,E,R,T,Y,U,I,O,P,A,S,D,F,G,H,J,K,L,Z,X,C,V,B,N,M";
                alr += "q,w,e,r,t,y,u,i,o,p,a,s,d,f,g,h,j,k,l,z,x,c,v,b,n,m";
                alr += "1,2,3,4,5,6,7,8,9,0";
                
                char[] a = { ','};

                String pwd = "";
                string temp = "";
                
                String[] b = alr.Split(a);

                for (int i = 0; i < 6; i++)
                {
                    temp = b[(random.Next(0, b.Length))];
                    pwd += temp;
                }
                return pwd;

            }
        }
    }
}
