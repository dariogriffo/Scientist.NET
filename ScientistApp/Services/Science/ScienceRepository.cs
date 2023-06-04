using GitHub;
using ScientistApp.Models;
using ScientistApp.Services.NoSql;
using ScientistApp.Services.SqlRepository;

namespace ScientistApp.Services.Science;

public class ScienceRepository : IUsersRepository
{
    private IScientist _scientist;
    private SqlUsersRepository _sql;
    private NoSqlUsersRepository _noSql;

    public ScienceRepository(IScientist scientist, SqlUsersRepository sql, NoSqlUsersRepository noSql)
    {
        _scientist = scientist;
        _sql = sql;
        _noSql = noSql;
    }

    public Task<User> GetById(Guid id)
    {
        return
            _scientist
                .ExperimentAsync<User>(
                    "get-user-id",
                    experiment =>
                    {
                        experiment.AddContext("user-id",id);
                        experiment.RunIf(async () => id != Guid.Empty);
                        experiment.Use(() => _sql.GetById(id));
                        experiment.Try(() => _noSql.GetById(id));
                        experiment.Compare((control, candidate) => control.FirstName == candidate.FirstName);
                    });
    }
}