using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AspMvcProject.Models
{
    public class BaseEquipment
    {
        public string Name { get; set; }
        public int EcCount { get; set; }
        public DateTime EntryDate { get; set; }
        public List<BaseEquipment> ListEquipment { get; set; }
        public BaseEquipment()
        {
            ListEquipment = new List<BaseEquipment>();
        }
        public static List<BaseEquipment> ListEquipmentData()
        {
            List<BaseEquipment> plstData = new List<BaseEquipment>();
            for (int i = 0; i < 50; i++)
            {
               
                BaseEquipment baseEquipment = new BaseEquipment();
                baseEquipment.Name = "Laptop_" + i ;
                baseEquipment.EcCount = 5+i;
                baseEquipment.EntryDate = DateTime.Now.Date;
                plstData.Add(baseEquipment);
            }
            return (plstData);



            // baseEquipment = new BaseEquipment();
            //baseEquipment.Name = "Mouse";
            //baseEquipment.EcCount = 3;
            //baseEquipment.EntryDate = DateTime.Now.Date;
            //plstData.Add(baseEquipment);

            //baseEquipment = new BaseEquipment();
            //baseEquipment.Name = "Keyeboard";
            //baseEquipment.EcCount = 3;
            //baseEquipment.EntryDate = DateTime.Now.Date;
            //plstData.Add(baseEquipment);




        }
    }
}