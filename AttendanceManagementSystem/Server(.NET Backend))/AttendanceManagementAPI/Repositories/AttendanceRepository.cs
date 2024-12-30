using AttendanceManagementAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace AttendanceManagementAPI.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        // Constructor
        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        // Fetch all Attendance records
        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync(); // Ensure _context.Attendances is a DbSet<Attendance>
        }

        // Add a new Attendance record
        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);  // Add the new Attendance to the DbSet
            await _context.SaveChangesAsync();                // Save the changes to the database
        }

        // Fetch Attendance by Id (Updated with null check)
        public async Task<Attendance> GetByIdAsync(int id, Attendance a)
        {
            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(a =>(int)a.Id == id);  // Find by Id asynchronously

            // Check for null and throw an exception if the attendance is not found
            if (attendance == null)
            {
                throw new KeyNotFoundException($"Attendance with ID {id} not found."); // Handle the null case
            }

            return attendance;
        }

        // Update an existing Attendance record
        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();        // Save the changes to the database
        }

        // Delete an Attendance record
        public async Task DeleteAsync(int id)
        {
            var attendance = await _context.Attendances
                .FirstOrDefaultAsync(a => (int)a.Id == id);  // Find by Id asynchronously
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);  // Remove the Attendance from the DbSet
                await _context.SaveChangesAsync();        // Save the changes to the database
            }
        }

        public List<Attendance> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Attendance attendance)
        {
            throw new NotImplementedException();
        }
    }
}
