using System;
using System.Collections.Generic;
using System.Xml;

namespace Copilot.Sw.Models
{
    public class ExecuteSkillModel
    {
        public string SkillName { get; set; }

        public string Description { get; set; }
    }

    public class SwPlanModel
    {
        public List<ExecuteSkillModel> ExecuteSkills { 