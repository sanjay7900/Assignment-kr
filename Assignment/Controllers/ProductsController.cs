using Assignment.Models.ViewModels;
using Assignment.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace Assignment.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService= productService;    
            _mapper= mapper;    
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        { 
            if (ModelState.IsValid)
            {

            }
            await _productService.AddProduct(model,1);
            
            return  RedirectToAction("GetProduct");  

        }
        [HttpGet]
        public async Task<IActionResult> GetProduct(int pagenumber=1,int size=10)
        { var c = await _productService.GetAllProductsCount();
            ViewData["PageCount"] = c<10?1:c/10;
            var data = await _productService.GetAllProducts(pagenumber, size);
            var product = new BulkProductViewModel
            {
                Products = data.Select(s => new ProductViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    ImagePath = s.ImagePath,


                }).ToList()
            };


            return View(product);

        }
        public async Task<IActionResult> GetProductPagination(int pagenumber = 1, int size = 10)
        {
            var data = await _productService.GetAllProducts(pagenumber, size);
            var product = new BulkProductViewModel
            {
                Products = data.Select(s => new ProductViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    ImagePath = s.ImagePath,


                }).ToList()
            };


            return PartialView("_ProductPaginationData", product);

        }

        [HttpPost]
        public async Task<IActionResult> Update(List<int> id,int Action)
        {

            if (Action == 1)
            {
                TempData["AllId"]=JsonConvert.SerializeObject(id);
               return Redirect("BulkUpdate");  

            }
            if(Action == 0)
            {

                var data= _mapper.Map<List<ProductViewModel>>(await _productService.GetAllProducts(id));

                await _productService.BulkUpdate(new BulkProductViewModel { Products=data}, 0, 2);
                return Redirect("GetProduct");
            }



            return BadRequest("Error while deleting");



        }
        public async Task<IActionResult> BulkUpdate()
        {
            List<int> id = JsonConvert.DeserializeObject<List<int>>(TempData["AllId"]!.ToString()!)!;
            var data =  _productService.GetAllProducts(id).Result.Select(s => new ProductViewModel
            {
                Price=s.Price,
                ImagePath=s.ImagePath,  
                Name = s.Name,   
               Id=s.Id,

            }).ToList();


            return View(new BulkProductViewModel
            {
                Products=data,
            });
        }
        [HttpPost]
        public async Task<IActionResult> BulkUpdatedata(BulkProductViewModel productViewModels)
        {
             var data=  _productService.BulkUpdate(productViewModels, 1, 1);
 
            return Redirect("GetProduct");
           


        }
        //public async Task<IActionResult> GetAuditData()
        //{
            
        //}
       



    }
}
