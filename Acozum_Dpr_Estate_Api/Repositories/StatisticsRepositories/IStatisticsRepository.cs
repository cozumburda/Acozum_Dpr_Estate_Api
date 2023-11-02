namespace Acozum_Dpr_Estate_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestestBuildingYear();
        int AverageRoomCount();
        int ActiveEmployeeCount();

    }
}
