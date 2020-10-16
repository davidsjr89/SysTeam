using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.BD
{
    public static class ConfiguracaoSQLServer
    {
        public static string StringDeConexao()
        {
            return "Server=localhost;Database=SysTeam;User Id=sa;Password=123456;";
        }
    }
}
