using AspNet.Test.Data.PostgreSql;
using AspNet.Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Test.Business
{
    public class ProductBusiness
    {
        private readonly ProductData _productData;

        public ProductBusiness()
        {
            // TODO: Implements Dependency Injection
            this._productData = new ProductData();
        }

        public IList<Product> GetAll()
            => this._productData.GetAll();
    }
}
