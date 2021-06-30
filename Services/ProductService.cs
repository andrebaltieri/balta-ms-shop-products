using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace BaltaShop.Products.Services
{
    public class ProductService : Products.ProductService.ProductServiceBase
    {
        public override Task<GetProductReply> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            return base.GetProduct(request, context);
        }
    }
}
