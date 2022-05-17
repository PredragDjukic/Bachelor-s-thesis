using Diplomski.BLL.DTOs.BundleDTOs;

namespace Diplomski.BLL.Interfaces;

public interface IBundleService
{
    BundleReadDto Create(int exerciserId, BundleCreateDto dto);
}