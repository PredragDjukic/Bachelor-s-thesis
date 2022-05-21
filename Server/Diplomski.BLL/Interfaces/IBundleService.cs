using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces;

public interface IBundleService
{
    BundleReadDto GetRead(int userId, int id);
    Bundle Get(int id);
    BundleReadDto Create(int exerciserId, BundleCreateDto dto);
}