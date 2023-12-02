using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication4.Controller
{
    public class SanPhamController : ApiController
    {
        public string connection = System.Configuration.ConfigurationManager.ConnectionStrings["TESTConnectionString"].ConnectionString;
        [HttpGet]
        public List<SanPham> laytoanbosanpham()
        {
            CSDLTestDataContext context = new CSDLTestDataContext(connection);
            List<SanPham> ds = context.SanPhams.ToList();
            foreach (SanPham s in ds)
            {
                s.MaDanhMuc = null;
            }
            return ds;
        }
        [HttpGet]
        public SanPham SanPham(int id)
        {
            CSDLTestDataContext context = new CSDLTestDataContext(connection);
            SanPham sanPham = context.SanPhams.FirstOrDefault(x=> x.MaDanhMuc == id);
            if (sanPham != null) sanPham.MaDanhMuc = null;
            return sanPham;
        }
    }
}
