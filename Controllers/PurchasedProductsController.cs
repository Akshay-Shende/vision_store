using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionStore.Dto;
using VisionStore.Repositories;

namespace VisionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedProductsController : ControllerBase
    {
        private readonly PurchasedProductsRepository _purchasedProductsRepository;

        public PurchasedProductsController(PurchasedProductsRepository purchasedProductsRepository)
        {
            _purchasedProductsRepository = purchasedProductsRepository;
        }

        [HttpPost]
        public IActionResult Post(List<PurchasedProductsDto> purchasedProductsDtos)
        {
            var result = _purchasedProductsRepository.Create(purchasedProductsDtos);

            if (result ==null || result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
