using LostWKND.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LostWKND.Helpers
{
    public static class LookupHelper
    {
        static LookupHelper()
        {
            var lookups = new List<Lookup>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LostWKNDConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Lookup";
                cmd.Connection = conn;

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var lookup = new Lookup();

                    lookup.ID = dr.GetInt32(0);
                    lookup.Type = dr.GetString(1);
                    lookup.Name = dr.GetString(2);

                    lookups.Add(lookup);
                }
            }

            LookupHelper.Type = new Dictionary<string, Dictionary<string, Lookup>>();
            
            lookups.ForEach(lookup =>
            {
                if (LookupHelper.Type.Keys.Any(key => key == lookup.Type))
                {
                    LookupHelper.Type[lookup.Type].Add(lookup.Name, lookup);
                }
                else
                {
                    LookupHelper.Type[lookup.Type] = new Dictionary<string, Lookup>();
                    LookupHelper.Type[lookup.Type].Add(lookup.Name, lookup);
                }
                
            });
        }

        public static Dictionary<string, Dictionary<string, Lookup>> Type;
    }
}