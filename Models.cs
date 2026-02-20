namespace AZ204CosmosDBDemo
{
    internal class Models
    {
        public record Employee(
            string id,
            string name,
            string role,
            string departament
        );
    }
}
