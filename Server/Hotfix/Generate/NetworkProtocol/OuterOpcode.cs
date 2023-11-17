namespace Fantasy
{
	public static partial class OuterOpcode
	{
		 public const int C2R_RegisterRequest = 110000001;
		 public const int R2C_RegisterResponse = 160000001;
		 public const int C2R_LoginRequest = 110000002;
		 public const int R2C_LoginResponse = 160000002;
		 public const int C2G_RegisterRequest = 110000003;
		 public const int G2C_RegisterResponse = 160000003;
		 public const int C2G_LoginRequest = 110000004;
		 public const int G2C_LoginResponse = 160000004;
		 public const int C2G_EnterMapRequest = 110000005;
		 public const int G2C_EnterMapResponse = 160000005;
		 public const int C2G_TestMessage = 100000001;
		 public const int G2C_TestPushMessage = 100000002;
		 public const int G2Map_CreatePlayerRequest = 200000001;
		 public const int Map2G_CreatePlayerResponse = 250000001;
		 public const int C2Map_ExitRequest = 200000002;
		 public const int Map2C_ExitResponse = 250000002;
		 public const int C2Map_MoveMessage = 190000001;
		 public const int Map2C_MoveBroadcast = 190000002;
	}
}
