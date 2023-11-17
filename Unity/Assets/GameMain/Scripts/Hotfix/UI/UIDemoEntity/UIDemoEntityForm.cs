using UnityEngine;

public partial class UIDemoEntityForm : UIFixBaseForm
{
	protected override void OnInit(object userData) {
		base.OnInit(userData);
		GetBindComponents(gameObject);

        ShowEntity();
	}


	void ShowEntity()
    {
        UIEntityData tmpData = new UIEntityData(GameEntry.Entity.GenEntityId(), 1, Const.EntityGroup.UIEntity, "Ball_Machine");
        tmpData.Position = new Vector3(1000, 0, 5);
        tmpData.Scale = new Vector3(3, 3, 3);
        GameEntry.Entity.ShowEntity(typeof(UIEntity), Const.EntityGroup.UIEntity, 1, tmpData);
    }
}

