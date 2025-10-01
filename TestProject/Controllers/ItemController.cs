using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using TestProject.Data;
   using  TestProject .Models;
namespace TestProject.Controllers
{
    public class ItemController : Controller
    {
        private readonly MyAppContextcs _context;

        public ItemController(MyAppContextcs context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var   items   = await _context.Student_Courses  .Include  (sc => sc.Student) .Include   (sc =>  sc.Course )   .ToListAsync();
            return View(items);
        }
        public    IActionResult   Create  (){

            // ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            Item item = new Item { Name = "Doraemon" };
            _context.Items.Add(item);
            _context.SaveChanges();



            return View();
             
        }


        [HttpPost] // Chỉ nhận POST requests
        public async Task<IActionResult> Create([Bind("ItemId,Name,Price,CategoryId")] Item item)
        {
            if (ModelState.IsValid) // Kiểm tra validation    //  kiểu tra   dữ   liệu Item  item  có  hợp  lệ  không 
            {
                _context.Items.Add(item); // Thêm vào DbContext
                await _context.SaveChangesAsync(); // Lưu vào database


               return   RedirectToAction("Index" , "Item");   // sang ItemController.Index // Chuyển hướng
            }
            return View(item); // Nếu invalid, trả về view với data
        }



        public    async  Task    <IActionResult>   Edit     (int  id)
        {
           var  item = await _context.Items.FirstOrDefaultAsync(x => x.ItemId == id);
            return    View(item);
        }


        
        [HttpPost] // Chỉ nhận POST requests
        public async Task<IActionResult> Edit( [Bind("ItemId,Name,Price")] Item item)
        {
            if (ModelState.IsValid) // Kiểm tra validation    //  kiểu tra   dữ   liệu Item  item  có  hợp  lệ  không 
            {
                _context.Items.Update(item); // Thêm vào DbContext
                await _context.SaveChangesAsync(); // Lưu vào database


                return RedirectToAction("Index", "Item");   // sang ItemController.Index // Chuyển hướng
            }
            return View(item); // Nếu invalid, trả về view với data
        }

        

        public   async      Task   <IActionResult>   Delete    (int id   )
        { 
            var  item  =  await _context.Items.FirstOrDefaultAsync(x => x.ItemId == id);    
            return View(item);
              
        }


        [HttpPost] // Chỉ nhận POST requests
        public async Task<IActionResult> Delete([Bind("ItemId,Name,Price")] Item item)
        {
            var     deleteItem  =  await _context.Items.FindAsync   (item.ItemId) ;

            if    (deleteItem  !=   null)
            {
                  _context.Items.Remove(deleteItem); // Thêm vào DbContext
                  await  _context.SaveChangesAsync(); // Lưu vào database

                    return RedirectToAction("Index", "Item");   // sang ItemController.Index // Chuyển hướng

            } 
            return View(item); // Nếu invalid, trả về view với data 


        }




    }

}
