﻿using FMS.Contract.Farm;
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
                    if (animalProfileVm.AnimalCode == -1)
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

                    animalProfile.FarmID = FARMID;
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
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + animalProfile.FarmID + "/AnimalProfile/" + animalProfile.AnimalCode + "/");
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
        [Route("GetAnimalProfile/{AnimalCode}")]
        public IHttpActionResult GetAnimalProfile(int AnimalCode)
        {
            try
            {
                AnimalProfile animalProfile = new AnimalProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalProfile = uow.AnimalProfileRepository.Get(x => x.AnimalCode == AnimalCode && x.FarmID == FARMID);

                    var animalStatus = uow.LookupRepository.GetAll(x => x.LookupCategory == Utility.CONFIG_ANIMALSTATUS).ToList();
                    var gender = uow.LookupRepository.GetAll(x => x.LookupCategory == Utility.CONFIG_GENDER).ToList();

                    animalProfile = animalProfile == null ? new AnimalProfile { AnimalCode = -1 } : animalProfile;
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
        [Route("GetAnimalProfileList")]
        public IHttpActionResult GetFarmProfileList()
        {
            try
            {
                List<AnimalProfile> animalProfileList = new List<AnimalProfile>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalProfileList = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FARMID).ToList();

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


        [HttpGet]
        [Route("GetAnimalCodeList/{AnimalCode}")]
        public IHttpActionResult GetAnimalCodeList(int AnimalCode)
        {
            try
            {
                AnimalProfile AnimalCodeList = new AnimalProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    AnimalCodeList = uow.AnimalProfileRepository.Get(x => x.FarmID == FARMID && x.AnimalCode == AnimalCode);
                    int age = (DateTime.UtcNow - AnimalCodeList.DateOfBirth.Value).Days;// (DateTime.UtcNow - AnimalCodeList.DateOfBirth).TotalDays.ToString();

                    return Ok(new
                    {
                        age
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetAnimalStatusCode/{AnimalCode}")]
        public IHttpActionResult GetAnimalStatusCode(int AnimalCode)
        {
            try
            {
                AnimalProfile AnimalCodeList = new AnimalProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    AnimalCodeList = uow.AnimalProfileRepository.Get(x => x.FarmID == FARMID && x.AnimalCode == AnimalCode);
                    int animalstatuscode = AnimalCodeList.AnimalStatus;

                    return Ok(new
                    {
                        animalstatuscode
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
