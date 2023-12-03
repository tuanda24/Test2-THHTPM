using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication4.Controller
{
    public class DanhMucController : ApiController
    {
        public string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TESTConnectionString"].ConnectionString;
        [HttpGet]
        public List<DanhMuc> laytoanboDanhMuc()
        {
            CSDLTestDataContext context = new CSDLTestDataContext(connection);
            List<DanhMuc> dsDM = context.DanhMucs.ToList();
            return dsDM;
        }
        [HttpGet]
        public DanhMuc DanhMuc(int id)
        {
            CSDLTestDataContext context = new CSDLTestDataContext(connection);
            DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == id);
            if (dm != null) dm.MaDanhMuc = null;
            return dm;
        }
        [HttpPost]
        public bool LuuDanhMuc(int madm, string tendm)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext(connection);
                DanhMuc dm = new DanhMuc();
                dm.MaDanhMuc = madm;
                dm.TenDanhMuc = tendm;
                context.DanhMucs.InsertOnSubmit(dm);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        [HttpPut]
        public bool SuaDanhMuc(int madm, string tendm)
        {
            CSDLTestDataContext context = new CSDLTestDataContext(connection);
            DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == madm);
            if (dm != null)
            {
                dm.TenDanhMuc = tendm;
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool XoaDanhMuc(int madm)
        {
            try
            {
                CSDLTestDataContext context = new CSDLTestDataContext(connection);
                DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == madm);
                if (dm != null)
                {
                    context.DanhMucs.DeleteOnSubmit(dm);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
     }
}
