﻿namespace Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {        
        int ProductCountByEmployeeId(int id);        
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();        
    }
}
