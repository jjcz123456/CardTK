using System;

namespace com.pokertk.data.vo
{

	[Serializable]
	public class SysMineLayoutVO
	{
        public long sml_id;
		public long sml_user_id;
		public long sml_cmi_id;
		public int sml_current_hp;
		public int sml_total_hp;
		public int sml_output;
		public long sml_general_id;
		public long sml_rabbit_id;
		public int sml_is_lead;
		public int sml_fighting;
		public int sml_coordinate_x;
		public int sml_coordinate_y;
		public CfgMineItemVO sml_cmiVO;
	}
}