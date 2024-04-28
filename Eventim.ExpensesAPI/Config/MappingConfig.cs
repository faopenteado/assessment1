using AutoMapper;
using Eventim.Expenses.Model;
using Eventim.Expenses.Model.Context;
using Eventim.ExpensesAPI.Data.ValueObjects;


namespace Eventim.ExpensesAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ExpensesGroupsVO, ExpensesGroups>();
                config.CreateMap<ExpensesGroups, ExpensesGroupsVO>();
            });
                       

            return mappingConfig;
        }
    }
}
