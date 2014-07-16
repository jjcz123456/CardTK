using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Msg
{
    public class SysAccountVO
    {

        private static const long serialVersionUID = 9193370087622536341L;
        private long saId;
        private string saName;
        private string saPassword;
        private string saCode;
        private int saFavoriteIsGet;

        public string getSaPassword()
        {
            return saPassword;
        }

        public void setSaPassword(string saPassword)
        {
            this.saPassword = saPassword;
        }

        public long getSaId()
        {
            return saId;
        }

        public void setSaId(long saId)
        {
            this.saId = saId;
        }

        public string getSaName()
        {
            return saName;
        }

        public void setSaName(string saName)
        {
            this.saName = saName;
        }

        public string getSaCode()
        {
            return saCode;
        }

        public void setSaCode(string saCode)
        {
            this.saCode = saCode;
        }

        public int getSaFavoriteIsGet()
        {
            return saFavoriteIsGet;
        }

        public void setSaFavoriteIsGet(int saFavoriteIsGet)
        {
            this.saFavoriteIsGet = saFavoriteIsGet;
        }

    }

}
