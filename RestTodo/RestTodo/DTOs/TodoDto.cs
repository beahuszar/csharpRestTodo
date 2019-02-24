namespace RestTodo.DTOs
{
    public class TodoDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }
        public long? AssigneeId { get; set; }
    }
}
