//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年9月18日 21:50:07
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace ETModel
{
    [Title("给指定Unit添加Buff，支持多个对象", TitleAlignment = TitleAlignments.Centered)]
    public class NP_AddBuffToSpecifiedUnitAction: NP_ClassForStoreAction
    {
        [LabelText("要添加的Buff的信息")]
        public VTD_BuffInfo BuffDataInfo = new VTD_BuffInfo();

        public NP_BlackBoardRelationData NPBalckBoardRelationData = new NP_BlackBoardRelationData() {};

        public override Action GetActionToBeDone()
        {
            this.Action = this.AddBuffToSpecifiedUnit;
            return this.Action;
        }

        public void AddBuffToSpecifiedUnit()
        {
            Unit unit = Game.Scene.GetComponent<UnitComponent>().Get(this.Unitid);
            BuffPoolComponent buffPoolComponent = Game.Scene.GetComponent<BuffPoolComponent>();
            foreach (var targetUnitId in NPBalckBoardRelationData.GetBlackBoardValue<List<long>>(this.BelongtoRuntimeTree.GetBlackboard()))
            {
                for (int i = 0; i < BuffDataInfo.Layers; i++)
                {
                    buffPoolComponent.AcquireBuff(BelongtoRuntimeTree.BelongNP_DataSupportor, BuffDataInfo.BuffId.Value, unit,
                        Game.Scene.GetComponent<UnitComponent>().Get(targetUnitId));
                }
            }
        }
    }
}