using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces;

public interface IBundleService
{
    IEnumerable<BundleReadDto> GetActiveByTrainer(int trainerId);
    IEnumerable<BundleReadDto> GetActiveByExerciser(int exerciserId);
    BundleReadDto GetRead(int userId, int id);
    Bundle Get(int id);
    BundleReadDto Create(int exerciserId, BundleCreateDto dto);
    void Delete(int userId, int id);
}