using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data_Access_Later
{
    public class CampaignDAL : BaseDAL
    {
        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return db.Campaigns.ToList();
        }

        public IEnumerable<Campaign> GetCampaignsById(int id)
        {
            return db.Campaigns.Where(x => x.id == id).ToList();
        }

        public Campaign CreateCampaign(Campaign campaign)
        {
            db.Campaigns.Add(campaign);
            db.SaveChanges();
            return campaign;
        }

        public Campaign UpdateCampaign(Campaign campaign)
        {
            db.Entry(campaign).State = EntityState.Modified;
            //db.SaveChanges();
            return campaign;
        }

        public void DeleteCampaign(int id)
        {
            db.Campaigns.Remove(db.Campaigns.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyCampaign(int id)
        {
            return db.Campaigns.Any(x => x.id == id);
        }
    }
}