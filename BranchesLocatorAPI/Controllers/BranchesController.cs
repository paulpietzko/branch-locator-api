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
    public class BranchesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BranchesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
        public IActionResult AddBranch(AddBranchDto addBranchDto)
        {
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
                Base64Image = addBranchDto.Base64Image
            };

            dbContext.Branches.Add(branchEntity);
            dbContext.SaveChanges();

            return Ok(branchEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateBranch(Guid id, UpdateBranchDto updateBranchDto)
        {
            var branch = dbContext.Branches.Find(id);

            if (branch is null)
                return NotFound();

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
            branch.Base64Image = updateBranchDto.Base64Image;

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
