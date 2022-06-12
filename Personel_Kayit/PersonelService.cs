using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Kayit
{
    public class PersonelService
    {
        public string ConnectionString { get; set; } = @"Server=(localdb)\ProjectModels;Integrated Security = true; Database= PersonelKayitDb;";

        public List<City> GetAllCity()
        {
            var sql = "SELECT * FROM City";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var affectedRows = connection.Query<City>(sql).ToList();
                Console.WriteLine($"Affected Rows: {affectedRows}");
                return affectedRows;
            }
        }

        public List<Personel> GetAllPersonels()
        {
            var sql = "SELECT * FROM Personels";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var affectedRows = connection.Query<Personel>(sql).ToList();
                Console.WriteLine($"Affected Rows: {affectedRows}");
                return affectedRows;
            }
        }

        public Personel GetPersonel(int id)
        {

            var sql = $"SELECT * FROM Personels Where Id={id}";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var affectedRows = connection.Query<Personel>(sql).FirstOrDefault();
                Console.WriteLine($"Affected Rows: {affectedRows}");
                return affectedRows;
            }
        }

        public void DeletePersonel(int id)
        {

            var sql = $"DELETE FROM Personels Where Id={id}";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var affectedRows = connection.Query(sql);
                Console.WriteLine($"Affected Rows: {affectedRows}");

            }
        }

        public void AddPersonel(Personel personel)
        {

            var sql = @"INSERT INTO [dbo].[Personels]([Name], [LastName], [CityId], [Salary], [Job], [MartialStatus]) 
                " + "VALUES (@Name, @LastName, @CityId, @Salary, @Job, @MartialStatus)";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var result = connection.Execute(sql, new
                {
                    personel.Name,
                    personel.LastName,
                    personel.CityId,
                    personel.Salary,
                    personel.Job,
                    personel.MartialStatus
                });

            }
        }


        public void UpdatePersonel(Personel personel)
        {

            var sql = @"UPDATE  [dbo].[Personels] 
            " + " SET [Name] = @Name, [LastName]= @LastName , [CityId]=@CityId, [Salary]=@Salary, [Job]=@Job, [MartialStatus]=@MartialStatus WHERE Id = @Id";


            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var result = connection.Execute(sql, new
                {
                    personel.Id,
                    personel.Name,
                    personel.LastName,
                    personel.CityId,
                    personel.Salary,
                    personel.Job,
                    personel.MartialStatus
                });

            }
        }
    }
}
