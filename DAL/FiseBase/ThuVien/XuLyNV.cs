using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Firebase
{
    public static class XuLyNV
    {
      
        public static IFirebaseClient CreateFirebaseClient()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "XKuwzOY4HTiAenNpT1YgR1Arq68ltpVz1rg5bdVE",
                BasePath = "https://qlsinhvien-b4bd4.firebaseio.com"
            };

            IFirebaseClient client;

            client = new FireSharp.FirebaseClient(config);
            return client;
        }

        public static async Task<Khoa> FirebaseGetThongTinKhoa(IFirebaseClient client, string rootName)
        {
            if (client != null)
            {
                //Khoa/2/
                FirebaseResponse response = await client.GetAsync(rootName);
                return response.ResultAs<Khoa>();
            }
            return null;
        }
        public static async Task<List<Khoa>> GetThongTinKhoa()
        {
            IFirebaseClient client = CreateFirebaseClient();

            List<Khoa> ds = new List<Khoa>();

            int i = 1;
            bool co = true;
            while (co)
            {
                try
                {
                    Khoa tk = await FirebaseGetThongTinKhoa(client, "Khoa/"+i.ToString()+"/");
                    if (tk == null)
                    {
                        co = false;
                        break;
                    }
                    i++;
                    ds.Add(tk);
                }
                catch(Exception ex)
                {
                    co = false;
                }
            }
            return ds;

        }
    }
}
