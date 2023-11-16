using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy.Hotfix;

public class AccountEntity : Entity
{
    public string RoleName;
    public uint RoleId;
    public long CreateTime;

    public override void Dispose()
    {
        RoleName = "";
        RoleId = 0;
        CreateTime = 0;

        base.Dispose();
    }
}

