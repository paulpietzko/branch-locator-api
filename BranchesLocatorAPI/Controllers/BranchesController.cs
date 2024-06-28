using BranchesLocatorAPI.Data;
using BranchesLocatorAPI.Models;
using BranchesLocatorAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BranchesLocatorAPI.Controllers
{
    // localhost:xxxx/api/branches
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpGet]
        public IActionResult GetAllBranches()
        {
            return Ok(dbContext.Branches.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBranchById(Guid id)
        {
            var branch = dbContext.Branches.Find(id);

            if(branch is null)
                return NotFound();

            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromForm] AddBranchDto addBranchDto, IFormFile? image)
        {
            string? imagePath = null;
            if (image != null)
            {
                // Generate a unique filename using branch ID and original filename
                var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(image.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                imagePath = Path.Combine("images", fileName);
            }

            var branchEntity = new Branch()
            {
                Email = addBranchDto.Email,
                Name = addBranchDto.Name,
                Canton = addBranchDto.Canton,
                Location = addBranchDto.Location,
                PostCode = addBranchDto.PostCode,
                Phone = addBranchDto.Phone,
                OpeningHours = addBranchDto.OpeningHours,
                Website = addBranchDto.Website,
                Lat = addBranchDto.Lat,
                Lng = addBranchDto.Lng,
                ImagePath = imagePath
            };

            dbContext.Branches.Add(branchEntity);
            dbContext.SaveChanges();

            return Ok(branchEntity);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBranch(Guid id, [FromForm] UpdateBranchDto updateBranchDto, IFormFile? image)
        {
            var branch = dbContext.Branches.Find(id);
            if (branch == null)
                return NotFound();

            string? imagePath = branch.ImagePath;

            if (image != null)
            {
                // Generate a unique filename using branch ID and original filename
                var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(image.FileName)}";
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                // Delete the old image if updating with a new one (optional, based on requirements)
                if (!string.IsNullOrEmpty(branch.ImagePath))
                {
                    var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, branch.ImagePath.Replace('/', '\\'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                imagePath = Path.Combine("images", fileName);
            }

            branch.Name = updateBranchDto.Name;
            branch.PostCode = updateBranchDto.PostCode;
            branch.Location = updateBranchDto.Location;
            branch.Email = updateBranchDto.Email;
            branch.Canton = updateBranchDto.Canton;
            branch.Website = updateBranchDto.Website;
            branch.OpeningHours = updateBranchDto.OpeningHours;
            branch.Phone = updateBranchDto.Phone;
            branch.Lat = updateBranchDto.Lat;
            branch.Lng = updateBranchDto.Lng;
            branch.ImagePath = imagePath;

            dbContext.SaveChanges();

            return Ok(branch);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteBranch(Guid id)
        {
            var branch = dbContext.Branches.Find(id);

            if (branch is null)
                return NotFound();

            dbContext.Branches.Remove(branch);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
