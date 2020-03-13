using NPoco;

namespace ServerMaster.Definitions.TableData.Main
{
    [TableName("_RefSkill"), PrimaryKey("ID")]
    public class RefSkill
    {
        public Enums.Genel.Service Service { get; set; }
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string Basic_Code { get; set; }
        public string Basic_Name { get; set; }
        public string Basic_Group { get; set; }
        public int Basic_Original { get; set; }
        public int Basic_Level { get; set; }
        public int Basic_Activity { get; set; }
        public int Basic_ChainCode { get; set; }
        public int Basic_RecycleCost { get; set; }
        public int Action_PreparingTime { get; set; }
        public int Action_CastingTime { get; set; }
        public int Action_ActionDuration { get; set; }
        public int Action_ReuseDelay { get; set; }
        public int Action_CoolTime { get; set; }
        public int Action_FlyingSpeed { get; set; }
        public int Action_Interruptable { get; set; }
        public int Action_Overlap { get; set; }
        public int Action_AutoAttackType { get; set; }
        public int Action_InTown { get; set; }
        public int Action_Range { get; set; }
        public int Target_Required { get; set; }
        public int TargetType_Animal { get; set; }
        public int TargetType_Land { get; set; }
        public int TargetType_Building { get; set; }
        public int TargetGroup_Self { get; set; }
        public int TargetGroup_Ally { get; set; }
        public int TargetGroup_Party { get; set; }
        public int TargetGroup_Enemy_M { get; set; }
        public int TargetGroup_Enemy_P { get; set; }
        public int TargetGroup_Neutral { get; set; }
        public int TargetGroup_DontCare { get; set; }
        public int TargetEtc_SelectDeadBody { get; set; }
        public int ReqCommon_Mastery1 { get; set; }
        public int ReqCommon_Mastery2 { get; set; }
        public int ReqCommon_MasteryLevel1 { get; set; }
        public int ReqCommon_MasteryLevel2 { get; set; }
        public int ReqCommon_Str { get; set; }
        public int ReqCommon_Int { get; set; }
        public int ReqLearn_Skill1 { get; set; }
        public int ReqLearn_Skill2 { get; set; }
        public int ReqLearn_Skill3 { get; set; }
        public int ReqLearn_SkillLevel1 { get; set; }
        public int ReqLearn_SkillLevel2 { get; set; }
        public int ReqLearn_SkillLevel3 { get; set; }
        public int ReqLearn_SP { get; set; }
        public int ReqLearn_Race { get; set; }
        public int Req_Restriction1 { get; set; }
        public int Req_Restriction2 { get; set; }
        public int ReqCast_Weapon1 { get; set; }
        public int ReqCast_Weapon2 { get; set; }
        public int Consume_HP { get; set; }
        public int Consume_MP { get; set; }
        public int Consume_HPRatio { get; set; }
        public int Consume_MPRatio { get; set; }
        public int Consume_WHAN { get; set; }
        public int UI_SkillTab { get; set; }
        public int UI_SkillPage { get; set; }
        public int UI_SkillColumn { get; set; }
        public int UI_SkillRow { get; set; }
        public string UI_IconFile { get; set; }
        public string UI_SkillName { get; set; }
        public string UI_SkillToolTip { get; set; }
        public string UI_SkillToolTip_Desc { get; set; }
        public string UI_SkillStudy_Desc { get; set; }
        public int AI_AttackChance { get; set; }
        public int AI_SkillType { get; set; }
        public int Param1 { get; set; } = 0;
        public int Param2 { get; set; } = 0;
        public int Param3 { get; set; } = 0;
        public int Param4 { get; set; } = 0;
        public int Param5 { get; set; } = 0;
        public int Param6 { get; set; } = 0;
        public int Param7 { get; set; } = 0;
        public int Param8 { get; set; } = 0;
        public int Param9 { get; set; } = 0;
        public int Param10 { get; set; } = 0;
        public int Param11 { get; set; } = 0;
        public int Param12 { get; set; } = 0;
        public int Param13 { get; set; } = 0;
        public int Param14 { get; set; } = 0;
        public int Param15 { get; set; } = 0;
        public int Param16 { get; set; } = 0;
        public int Param17 { get; set; } = 0;
        public int Param18 { get; set; } = 0;
        public int Param19 { get; set; } = 0;
        public int Param20 { get; set; } = 0;
        public int Param21 { get; set; } = 0;
        public int Param22 { get; set; } = 0;
        public int Param23 { get; set; } = 0;
        public int Param24 { get; set; } = 0;
        public int Param25 { get; set; } = 0;
        public int Param26 { get; set; } = 0;
        public int Param27 { get; set; } = 0;
        public int Param28 { get; set; } = 0;
        public int Param29 { get; set; } = 0;
        public int Param30 { get; set; } = 0;
        public int Param31 { get; set; } = 0;
        public int Param32 { get; set; } = 0;
        public int Param33 { get; set; } = 0;
        public int Param34 { get; set; } = 0;
        public int Param35 { get; set; } = 0;
        public int Param36 { get; set; } = 0;
        public int Param37 { get; set; } = 0;
        public int Param38 { get; set; } = 0;
        public int Param39 { get; set; } = 0;
        public int Param40 { get; set; } = 0;
        public int Param41 { get; set; } = 0;
        public int Param42 { get; set; } = 0;
        public int Param43 { get; set; } = 0;
        public int Param44 { get; set; } = 0;
        public int Param45 { get; set; } = 0;
        public int Param46 { get; set; } = 0;
        public int Param47 { get; set; } = 0;
        public int Param48 { get; set; } = 0;
        public int Param49 { get; set; } = 0;
        public int Param50 { get; set; } = 0;

        [SkipProperty, Ignore]
        public string Media_SkillName => Functions.Media.TextData.FindFromTextData(UI_SkillName);

        [SkipProperty, Ignore]
        public string Media_SkillToolTip => Functions.Media.TextData.FindFromTextData(UI_SkillToolTip);
    }
}