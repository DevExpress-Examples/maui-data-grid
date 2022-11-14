using Newtonsoft.Json.Linq;
using System.Reflection;

namespace AdvancedColumnLayout {
    public class EmployeesRepository {
        public IList<Employee> Employees { get; private set; }

        public EmployeesRepository() {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("employees");
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            Employees = jObject["Employees"].ToObject<List<Employee>>();
        }
    }
}
