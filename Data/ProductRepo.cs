using Supplier1API.Model;
namespace Supplier1API.Data
{
    public class ProductRepo
    {
        private AppDBContext _dbContext;


        public ProductRepo(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                if (product != null)
                {

                    _dbContext.Products.Add(product);
                    return Save();
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool Save()
        {
            try
            {
                int count = _dbContext.SaveChanges();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            return Save();
        }


        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _dbContext.Products.ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Product GetProductByID(int id)
        {
            try
            {
                return _dbContext.Products.FirstOrDefault(product => product.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Product GetProductByName(string name)
        {
            try
            {
                return _dbContext.Products
                    .AsEnumerable() // Forces client-side evaluation
                    .FirstOrDefault(product => product.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
