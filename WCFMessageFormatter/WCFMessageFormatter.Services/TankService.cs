using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFMessageFormatter.Contracts.ServiceContracts;
using WCFMessageFormatter.Contracts.DataContracts;

namespace WCFMessageFormatter.Services
{    
    public class TankService : ITankService
    {
        public List<Tank> RetrieveTanks(string alt)
        {
            return this.MockTankData();
        }

        public Organizition RetrieveOrganizitions(string alt)
        {
            return this.MockOrganizitionData();
        }

        public Organizition RetrieveOrganizitions2(string alt)
        {
            return this.MockOrganizitionData();
        }

        public TankCollection<string> RetrieveTankCollection(string tank)
        {
            return this.MockTankCollectionData();  
        }

        private List<Tank> MockTankData()
        {
            TankCollection<string> tankCollection1 = new TankCollection<string>();
            tankCollection1.CollectionName = "Collection1";
            tankCollection1.Add("String1");
            tankCollection1.Add("String2");

            TankCollection<Navigation<string>> navigationTankCollection = new TankCollection<Navigation<string>>
                                                                              {
                                                                                  new Navigation<string>
                                                                                      {
                                                                                          Obj = "String1"
                                                                                      },
                                                                                  new Navigation<string>
                                                                                      {
                                                                                          Obj = "String2"
                                                                                      }
                                                                              };
            

            return new List<Tank>()
            {
                new Tank()
                {
                     CanDive = true,
                     Speed = 50,
                     Weight = 100,
                     TankCollection = tankCollection1,
                      History = new List<string>()
                      {
                          "History1",
                          "History2"
                      }
                },
                new Tank()
                {
                     CanDive = false,
                     Weight = 100,
                     History = new List<string>()
                     {
                         "History1",
                         "History2"
                     },
                }
            };
        }

        private Organizition MockOrganizitionData()
        {
            Organizition organizitions = new Organizition()
                                              {
                                                  ResponseLink = "http://test",
                                                  Organizitions = new List<string>()
                                                                     {
                                                                         "Organizition1",
                                                                         "Organizition2"
                                                                     },
                                                  NavigationGenericCollection = new TankCollection<Navigation<string>>()
                                                                                    {
                                                                                        new Navigation<string>
                                                                                            {
                                                                                                Obj = "String1"
                                                                                            },
                                                                                        new Navigation<string>
                                                                                            {
                                                                                                Obj = "String2"
                                                                                            }
                                                                                    },
                                                  TankCollection = new TankCollection<Tank>()
                                                                       {
                                                                           new Tank()
                                                                               {
                                                                                   Speed = 10
                                                                               }
                                                                       },
                                                                       TankBytes = new byte[]
                                                                                       {
                                                                                           1,
                                                                                           2

                                                                                       }
                                              };
            organizitions.TankCollection.CollectionName = "TestTankCollection";
            organizitions.TankCollection = null;
            return organizitions;
        }

        private TankCollection<string> MockTankCollectionData()
        {
            TankCollection<string> tankCollection = new TankCollection<string>()
            {
                "tankCollection1",
                "tankCollection2"
            };
            tankCollection.CollectionName = "tankCollection";
            return tankCollection;
        }
    }
}
