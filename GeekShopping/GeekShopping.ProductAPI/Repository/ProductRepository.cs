using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVo>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVo>>(products);
        }

        public async Task<ProductVo> FindById(long id)
        {
            var product = await _context.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<ProductVo> Create(ProductVo vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<ProductVo> Update(ProductVo vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
