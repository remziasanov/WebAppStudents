using Client.LoadData;
using Client.ModelsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    class SchoolController : IBaseController<SchoolUI>
    {
        StudentController studentController;
        LoadDataFromJson<SchoolUI> schoolJson;
        public SchoolController()
        {
            studentController = new StudentController();
            schoolJson = new LoadDataFromJson<SchoolUI>();
        }

        public async Task<bool> Add(SchoolUI Entity)
        {
            return (await schoolJson.Add(studentController.schoolsLink, Entity)).IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit(SchoolUI Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SchoolUI> Get(int id)
        {
            List<SchoolUI> schooList = await studentController.ObjectLoad<SchoolUI>(studentController.schoolsLink);
            return schooList.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<SchoolUI>> Get()
        {
            return await studentController.ObjectLoad<SchoolUI>(studentController.schoolsLink);
        }
    }
}
