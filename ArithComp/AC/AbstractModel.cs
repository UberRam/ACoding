using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AC
{
    enum ModeE
    {
        MODE_ENCODE=0,
        MODE_DECODE=1
    }

    abstract class AbstractModel
    {
        public void Process(FileStream source, FileStream target, ModeE mode)
        {
            mSource = source;
            mTarget = target;

            if (mode == ModeE.MODE_ENCODE)
            {
                mAC.SetFile(mTarget);

                Encode();

                mAC.EncodeFinish();
            }
            else
            {
                mAC.SetFile(mSource);

                mAC.DecodeStart();

                Decode();
            }
        }

        protected abstract void Encode();
	    protected abstract void Decode();

	    protected ArithmeticCoderCS mAC = new ArithmeticCoderCS();
        protected FileStream mSource;
        protected FileStream mTarget;
    }
}
