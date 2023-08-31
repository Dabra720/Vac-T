using Vac_T.Areas.Identity.Data;
using Vac_T.Contexts;

namespace Vac_T.Data
{
    public static class DbInitializer
    {
        public static void DbInitialize(VacItContext context) {
            SeedEmployers(context);
        }

        private static void SeedEmployers(VacItContext context)
        {

            var employers = new List<Vac_TUser>()
            {
                new Vac_TUser(),
                new Vac_TUser(),
                new Vac_TUser()
            };

            foreach(Vac_TUser employer in employers)
            {

            }
        }
    }
}
