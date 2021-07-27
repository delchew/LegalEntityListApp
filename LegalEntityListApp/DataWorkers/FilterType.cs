using System.ComponentModel;

namespace LegalEntityListApp.DataWorkers
{
    public enum FilterType
    {
        [Description("and")]
        And,

        [Description("or")]
        Or,

        [Description("not")]
        Not,

        [Description("lt")]
        LessThan,

        [Description("gt")]
        GreaterThan,

        [Description("lte")]
        LessThanEqualTo,

        [Description("gte")]
        GreaterThanEqualTo,

        [Description("eq")]
        EqualTo,

        [Description("neq")]
        NotEqualTo,

        [Description("in")]
        In,

        [Description("nin")]
        NotIn,

        [Description("like")]
        Like
    }
}
