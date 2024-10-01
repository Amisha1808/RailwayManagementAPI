using Microsoft.EntityFrameworkCore;
using RailwayManagementAPI.Data;
using RailwayManagementAPI.Models;

namespace RailwayManagementAPI.Services
{
    public interface ITrainService
    {
        Task<IEnumerable<Train>> GetAllTrains();
        Task<Train> GetTrainById(int id);
        Task<Train> AddTrain(Train train);
        Task<Train> UpdateTrain(Train train);
        Task<bool> DeleteTrain(int id);
    }

    public class TrainService : ITrainService
    {
        private readonly ApplicationDbContext _context;

        public TrainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Train>> GetAllTrains()
        {
            return await _context.Trains.ToListAsync();
        }

        public async Task<Train> GetTrainById(int id)
        {
            return await _context.Trains.FindAsync(id);
        }

        public async Task<Train> AddTrain(Train train)
        {
            await _context.Trains.AddAsync(train);
            await _context.SaveChangesAsync();
            return train;
        }

        public async Task<Train> UpdateTrain(Train train)
        {
            _context.Trains.Update(train);
            await _context.SaveChangesAsync();
            return train;
        }

        public async Task<bool> DeleteTrain(int id)
        {
            var train = await _context.Trains.FindAsync(id);
            if (train == null)
                return false;

            _context.Trains.Remove(train);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}