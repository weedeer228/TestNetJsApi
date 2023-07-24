using Data.Models;
using DbRepository.Repositories.Interfaces;

namespace TestAssignment.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        private static  bool isMockCreated = false;
        public GeneralRepository(ICityRepository cityRepository, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, INoteRepository noteRepository, IOrdersRepository ordersRepository)
        {
            CityRepository = cityRepository;
            CompanyRepository = companyRepository;
            EmployeeRepository = employeeRepository;
            NoteRepository = noteRepository;
            OrdersRepository = ordersRepository;
        }
        public ICityRepository CityRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public INoteRepository NoteRepository { get; set; }
        public IOrdersRepository OrdersRepository { get; set; }
        /// <summary>
        /// нарушает все принципы, но зато генерирует дату, считаю что логику подобных методов, котрые предназначены для тестов не стоит размазывать по проекту
        /// </summary>
        /// <returns></returns>
        public async Task CreateMockData()
        {
            if (isMockCreated) return;
            isMockCreated = true;
            List<City> cityList = new List<City>();
            List<Employee> employeeList = new List<Employee>();
            List<Note> noteList = new List<Note>();
            List<Order> ordersList = new List<Order>();
            List<Company> companyList = new List<Company>();
            //создание
            for (int i = 0; i < 100; i++)
            {
                cityList.Add(new City() { Name = "City " + i });
                companyList.Add(new Company()
                {
                    Name = "Company " + i,
                    City = cityList.ElementAt(i),
                    State = "state " + i,
                    Phone = "phone Company " + i,

                });

                for (int j = 0; j < 101; j += 25)
                {

                    employeeList.Add(new Employee()
                    {
                        FirstName = "name " + j+i,
                        LastName = "Surname " + j+i,
                        BirthDate = new DateTime(1920 + i, (i / 12) + 1, (i / 4) + 1),
                        Title = i / 2 == 0 ? "Mr" : "Ms",
                        Position = (Positions)(i / 25),
                        Notes = new List<Note>()
                        {
                            new Note()
                            {
                                InvoiceNumber = 228+(i+1)*j,
                                Company = companyList.ElementAt(i),
                            }
                        },
                        Company = companyList.ElementAt(i)

                    });

                    ordersList.Add(new Order()
                    {
                        Date = new DateTime(2023 - i, (i / 12) + 1, (i / 25) + 1),
                        City = cityList.ElementAt(i / (j + 1)),
                        Company = companyList.ElementAt(i),
                    });


                }

            }
             cityList.ForEach(async c =>
            {

                await CityRepository.CreateAsync(c);
            });

            //Сопоставление данных и загрузка в бд

            companyList.ForEach(async c =>
            {
                await CompanyRepository.CreateAsync(c);
            });
        
            employeeList.ForEach(async e =>
            {
                await EmployeeRepository.CreateAsync(e);
            });
            ordersList.ForEach(async o =>
            {
                await OrdersRepository.CreateAsync(o);
            });
            noteList.AddRange(employeeList.SelectMany(e => e.Notes).Where(n => !noteList.Contains(n)));
            noteList.ForEach(async n =>
            {
                await NoteRepository.CreateAsync(n);
            });
            
            await CompanyRepository.SaveAsync();
        }
    }

    public interface IGeneralRepository
    {
        public ICityRepository CityRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public INoteRepository NoteRepository { get; set; }
        public IOrdersRepository OrdersRepository { get; set; }

        public Task CreateMockData();

    }
}
