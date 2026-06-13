namespace InterManagement.Application.Features.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQuery
    {
        public int Id { get; set; }

        public GetAdminByIdQuery(int id)
        {
            Id = id;
        }
    }
}