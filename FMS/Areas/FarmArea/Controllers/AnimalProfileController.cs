using FMS.Contract.Farm;
using FMS.Contract.ViewModel;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FMS.Areas.FarmArea.Controllers
{
    [RoutePrefix("api/AnimalProfile")]
    public class AnimalProfileController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(AnimalProfileVM animalProfileVm)
        {
            try
            {
                AnimalProfile animalProfile = new AnimalProfile();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (animalProfileVm.AnimalCode == 0)
                    {
                        animalProfile = new AnimalProfile();
                        animalProfile.CreatedBy = "ADMIN";
                        animalProfile.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        animalProfile = uow.AnimalProfileRepository.Get(x => x.AnimalCode == animalProfileVm.AnimalCode);

                        animalProfile.ModifiedBy = "ADMIN";
                        animalProfile.ModifiedOn = DateTime.UtcNow;
                    }

                    animalProfile.FarmID = animalProfileVm.FarmID;
                    animalProfile.AnimalCode = animalProfileVm.AnimalCode;
                    animalProfile.AnimalName = animalProfileVm.AnimalName;
                    animalProfile.AnimalSymbol = animalProfileVm.AnimalSymbol;
                    animalProfile.AnimalStatus = animalProfileVm.AnimalStatus;
                    animalProfile.CauseOfDeath = animalProfileVm.CauseOfDeath;
                    animalProfile.DateOfBirth = animalProfileVm.DateOfBirth;
                    animalProfile.Gender = animalProfileVm.Gender;
                    animalProfile.SireCode = animalProfileVm.SireCode;
                    animalProfile.BreederCode = animalProfileVm.BreederCode;
                    animalProfile.BreederFormula = animalProfileVm.BreederFormula;
                    animalProfile.Talents = animalProfileVm.Talents;
                    animalProfile.Weight = animalProfileVm.Weight;
                    animalProfile.FightingRecord = animalProfileVm.FightingRecord;
                    animalProfile.StandardPrice = animalProfileVm.StandardPrice;
                    animalProfile.Remarks = animalProfileVm.Remarks;

                    var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    if (animalProfileVm.FileName != null && animalProfileVm.FileName.Length > 0)
                    {
                        animalProfile.AnimalPhoto = myfilename;
                    }

                    uow.AnimalProfileRepository.Save(animalProfile);
                    uow.SaveChanges();

                    if (animalProfileVm.FileName != null && animalProfileVm.FileName.Length > 0)
                    {
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/FarmProfile/" + animalProfileVm.AnimalCode + "/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filepath = path + myfilename;
                        var bytess = Convert.FromBase64String(animalProfileVm.FileName);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }


                    return Ok(new
                    {
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetFarmProfile/{AnimalCode}/{FarmID}")]
        public IHttpActionResult GetFarmProfile(int AnimalCode, int FarmID)
        {
            try
            {
                AnimalProfile animalProfile = new AnimalProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalProfile = uow.AnimalProfileRepository.Get(x => x.AnimalCode == AnimalCode && x.FarmID == FarmID);

                    var animalStatus = uow.LookupRepository.GetAll(x => x.LookupCategory == "AnimalStatus").ToList();
                    var gender = uow.LookupRepository.GetAll(x => x.LookupCategory == "Gender").ToList();

                    return Ok(new
                    {
                        animalProfile,
                        gender,
                        animalStatus
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetFarmProfileList/{FarmID}")]
        public IHttpActionResult GetFarmProfileList(int FarmID)
        {
            try
            {
                List<AnimalProfile> animalProfileList = new List<AnimalProfile>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalProfileList = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FarmID).ToList();

                    return Ok(new
                    {
                        animalProfileList
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
